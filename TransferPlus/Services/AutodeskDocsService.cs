using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TransferPlus.Services;

public class AccHubModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class AccProjectModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class AccFolderModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool HasChildren { get; set; } = true;
}

public class AccItemModel
{
    public string Id { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string VersionId { get; set; } = string.Empty;
    public long ContentLength { get; set; }
    public DateTime? LastModified { get; set; }
}

public class AccUserProfileModel
{
    public string UserName { get; set; } = string.Empty;
    public string EmailId { get; set; } = string.Empty;
}

public static class AutodeskDocsService
{
    private static readonly HttpClient HttpClient = new();
    private static readonly string BaseUrl = "https://developer.api.autodesk.com";

    /// <summary>
    /// Official Client ID for TransferPlus published on Autodesk Platform Services (APS).
    /// Replace "YOUR_AUTODESK_APS_CLIENT_ID_HERE" with your official Client ID from https://aps.autodesk.com/myapps
    /// </summary>
    public static string DefaultClientId { get; set; } = "YOUR_AUTODESK_APS_CLIENT_ID_HERE";
    public static string DefaultRedirectUri { get; set; } = "http://localhost:8989/callback/";

    /// <summary>
    /// Generates PKCE code verifier and challenge for OAuth 2.0 security.
    /// </summary>
    public static (string CodeVerifier, string CodeChallenge) GeneratePkce()
    {
        byte[] bytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(bytes);
        }
        string codeVerifier = Convert.ToBase64String(bytes)
            .Replace("+", "-").Replace("/", "_").Replace("=", "");

        using (var sha256 = SHA256.Create())
        {
            byte[] challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
            string codeChallenge = Convert.ToBase64String(challengeBytes)
                .Replace("+", "-").Replace("/", "_").Replace("=", "");
            return (codeVerifier, codeChallenge);
        }
    }

    /// <summary>
    /// Builds the official Autodesk OAuth 2.0 Authorization URL.
    /// </summary>
    public static string GetOAuthAuthorizationUrl(string clientId, string redirectUri, string state, string codeChallenge)
    {
        string effectiveClientId = string.IsNullOrWhiteSpace(clientId) ? DefaultClientId : clientId;
        string effectiveRedirectUri = string.IsNullOrWhiteSpace(redirectUri) ? DefaultRedirectUri : redirectUri;
        string scope = Uri.EscapeDataString("data:read data:create data:write bucket:read user:read");

        return $"{BaseUrl}/authentication/v2/authorize?" +
               $"response_type=code&client_id={Uri.EscapeDataString(effectiveClientId)}" +
               $"&redirect_uri={Uri.EscapeDataString(effectiveRedirectUri)}" +
               $"&scope={scope}&state={Uri.EscapeDataString(state)}" +
               $"&code_challenge={Uri.EscapeDataString(codeChallenge)}" +
               $"&code_challenge_method=S256";
    }

    /// <summary>
    /// Starts a local HttpListener loopback server to capture the OAuth authorization code.
    /// </summary>
    public static async Task<string?> CaptureOAuthCodeViaLoopbackAsync(int port = 8989, CancellationToken cancellationToken = default)
    {
        string prefix = $"http://localhost:{port}/callback/";
        using var listener = new HttpListener();
        listener.Prefixes.Add(prefix);

        try
        {
            listener.Start();
            TelemetryLogger.LogInfo($"[AutodeskDocsService] Listening for OAuth callback at {prefix}...");

            using (cancellationToken.Register(() => { try { listener.Stop(); } catch { } }))
            {
                var context = await listener.GetContextAsync();
                var request = context.Request;
                var response = context.Response;

                string? code = request.QueryString["code"];
                string responseString = @"
<html>
<head><style>body { font-family: Segoe UI, sans-serif; text-align: center; margin-top: 50px; background: #F4F6F8; }</style></head>
<body>
<h2>Authentication Successful!</h2>
<p>You have successfully logged into Autodesk Construction Cloud for TransferPlus.</p>
<p>You may close this browser window and return to Revit.</p>
</body>
</html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                using var output = response.OutputStream;
                await output.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
                return code;
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in CaptureOAuthCodeViaLoopbackAsync", ex);
            return null;
        }
    }

    /// <summary>
    /// Exchanges OAuth authorization code for Access and Refresh Tokens.
    /// </summary>
    public static async Task<(bool Success, string AccessToken, string RefreshToken, string ErrorMessage)> ExchangeCodeForTokensAsync(
        string code,
        string codeVerifier,
        string clientId = "",
        string redirectUri = "",
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(code)) return (false, string.Empty, string.Empty, "Authorization code is empty.");

        string effectiveClientId = string.IsNullOrWhiteSpace(clientId) ? DefaultClientId : clientId;
        string effectiveRedirectUri = string.IsNullOrWhiteSpace(redirectUri) ? DefaultRedirectUri : redirectUri;

        try
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "client_id", effectiveClientId },
                { "redirect_uri", effectiveRedirectUri },
                { "code_verifier", codeVerifier }
            });

            var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/authentication/v2/token")
            {
                Content = content
            };

            var response = await HttpClient.SendAsync(request, cancellationToken);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsService] Code exchange failed: {response.StatusCode} - {json}");
                return (false, string.Empty, string.Empty, $"Code exchange failed: {response.ReasonPhrase}");
            }

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            string accessToken = root.GetProperty("access_token").GetString() ?? string.Empty;
            string refreshToken = root.TryGetProperty("refresh_token", out var rfProp) ? rfProp.GetString() ?? string.Empty : string.Empty;

            return (true, accessToken, refreshToken, string.Empty);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in ExchangeCodeForTokensAsync", ex);
            return (false, string.Empty, string.Empty, ex.Message);
        }
    }

    /// <summary>
    /// Refreshes an expired 3-legged OAuth access token using a refresh token.
    /// </summary>
    public static async Task<(bool Success, string AccessToken, string RefreshToken, string ErrorMessage)> RefreshTokenAsync(
        string refreshToken,
        string clientId = "",
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
            return (false, string.Empty, string.Empty, "Refresh token is empty.");

        string effectiveClientId = string.IsNullOrWhiteSpace(clientId) ? DefaultClientId : clientId;

        try
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken },
                { "client_id", effectiveClientId }
            });

            var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/authentication/v2/token")
            {
                Content = content
            };

            var response = await HttpClient.SendAsync(request, cancellationToken);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsService] Token refresh failed: {response.StatusCode} - {json}");
                return (false, string.Empty, string.Empty, $"Token refresh failed: {response.ReasonPhrase}");
            }

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            string newAccessToken = root.GetProperty("access_token").GetString() ?? string.Empty;
            string newRefreshToken = root.TryGetProperty("refresh_token", out var rfProp) ? rfProp.GetString() ?? refreshToken : refreshToken;

            return (true, newAccessToken, newRefreshToken, string.Empty);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in RefreshTokenAsync", ex);
            return (false, string.Empty, string.Empty, ex.Message);
        }
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/userprofile/v1/users/@me
    /// Fetches the authenticated user's profile info (Name, Email).
    /// </summary>
    public static async Task<AccUserProfileModel?> GetUserProfileAsync(string accessToken, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(accessToken)) return null;

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/userprofile/v1/users/@me");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            string firstName = root.TryGetProperty("firstName", out var fn) ? fn.GetString() ?? "" : "";
            string lastName = root.TryGetProperty("lastName", out var ln) ? ln.GetString() ?? "" : "";
            string email = root.TryGetProperty("emailId", out var em) ? em.GetString() ?? "" : "";
            string name = $"{firstName} {lastName}".Trim();
            if (string.IsNullOrWhiteSpace(name)) name = root.TryGetProperty("userName", out var un) ? un.GetString() ?? email : email;

            return new AccUserProfileModel { UserName = name, EmailId = email };
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in GetUserProfileAsync", ex);
            return null;
        }
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/project/v1/hubs
    /// Retrieves hubs accessible to the authenticated user.
    /// </summary>
    public static async Task<List<AccHubModel>> GetHubsAsync(string accessToken, CancellationToken cancellationToken = default)
    {
        var result = new List<AccHubModel>();
        if (string.IsNullOrWhiteSpace(accessToken)) return result;

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/project/v1/hubs");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                TelemetryLogger.LogWarning($"[AutodeskDocsService] GetHubsAsync failed: {response.StatusCode} - {err}");
                return result;
            }

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("data", out var dataArray) && dataArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in dataArray.EnumerateArray())
                {
                    string id = item.GetProperty("id").GetString() ?? string.Empty;
                    string name = item.GetProperty("attributes").GetProperty("name").GetString() ?? id;
                    result.Add(new AccHubModel { Id = id, Name = name });
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in GetHubsAsync", ex);
        }

        return result;
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/project/v1/hubs/{hubId}/projects
    /// Retrieves projects under a specific hub.
    /// </summary>
    public static async Task<List<AccProjectModel>> GetProjectsAsync(string accessToken, string hubId, CancellationToken cancellationToken = default)
    {
        var result = new List<AccProjectModel>();
        if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(hubId)) return result;

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/project/v1/hubs/{Uri.EscapeDataString(hubId)}/projects");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsService] GetProjectsAsync failed for hub '{hubId}': {response.StatusCode}");
                return result;
            }

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("data", out var dataArray) && dataArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in dataArray.EnumerateArray())
                {
                    string id = item.GetProperty("id").GetString() ?? string.Empty;
                    string name = item.GetProperty("attributes").GetProperty("name").GetString() ?? id;
                    result.Add(new AccProjectModel { Id = id, Name = name });
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in GetProjectsAsync for hub '{hubId}'", ex);
        }

        return result;
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/data/v1/projects/{projectId}/folders/root
    /// Retrieves the root folder for a project.
    /// </summary>
    public static async Task<AccFolderModel?> GetRootFolderAsync(string accessToken, string projectId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(projectId)) return null;

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/data/v1/projects/{Uri.EscapeDataString(projectId)}/folders/root");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("data", out var data))
            {
                string id = data.GetProperty("id").GetString() ?? string.Empty;
                string name = data.GetProperty("attributes").GetProperty("name").GetString() ?? "Project Files";
                return new AccFolderModel { Id = id, Name = name, HasChildren = true };
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in GetRootFolderAsync for project '{projectId}'", ex);
        }

        return null;
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/data/v1/projects/{projectId}/folders/{folderId}/contents
    /// Retrieves subfolders and items inside a folder.
    /// </summary>
    public static async Task<(List<AccFolderModel> Subfolders, List<AccItemModel> RfaItems)> GetFolderContentsAsync(
        string accessToken,
        string projectId,
        string folderId,
        CancellationToken cancellationToken = default)
    {
        var subfolders = new List<AccFolderModel>();
        var rfaItems = new List<AccItemModel>();

        if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(projectId) || string.IsNullOrWhiteSpace(folderId))
            return (subfolders, rfaItems);

        try
        {
            string url = $"{BaseUrl}/data/v1/projects/{Uri.EscapeDataString(projectId)}/folders/{Uri.EscapeDataString(folderId)}/contents";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsService] GetFolderContentsAsync failed for folder '{folderId}': {response.StatusCode}");
                return (subfolders, rfaItems);
            }

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("data", out var dataArray) && dataArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var element in dataArray.EnumerateArray())
                {
                    string type = element.GetProperty("type").GetString() ?? string.Empty;
                    string id = element.GetProperty("id").GetString() ?? string.Empty;
                    var attributes = element.GetProperty("attributes");

                    if (type.Equals("folders", StringComparison.OrdinalIgnoreCase))
                    {
                        string folderName = attributes.GetProperty("displayName").GetString() ?? "Subfolder";
                        subfolders.Add(new AccFolderModel { Id = id, Name = folderName, HasChildren = true });
                    }
                    else if (type.Equals("items", StringComparison.OrdinalIgnoreCase))
                    {
                        string displayName = attributes.GetProperty("displayName").GetString() ?? string.Empty;
                        if (displayName.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase))
                        {
                            long size = attributes.TryGetProperty("storageSize", out var szProp) ? szProp.GetInt64() : 0;
                            DateTime? lastMod = null;
                            if (attributes.TryGetProperty("lastModifiedTime", out var lmtProp) &&
                                DateTime.TryParse(lmtProp.GetString(), out var dt))
                            {
                                lastMod = dt;
                            }

                            rfaItems.Add(new AccItemModel
                            {
                                Id = id,
                                DisplayName = displayName,
                                ContentLength = size,
                                LastModified = lastMod
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in GetFolderContentsAsync for folder '{folderId}'", ex);
        }

        return (subfolders, rfaItems);
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/data/v1/projects/{projectId}/items/{itemId}/versions
    /// Gets the latest version and download URL for an item.
    /// </summary>
    public static async Task<string?> GetLatestVersionDownloadUrlAsync(
        string accessToken,
        string projectId,
        string itemId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(projectId) || string.IsNullOrWhiteSpace(itemId))
            return null;

        try
        {
            string url = $"{BaseUrl}/data/v1/projects/{Uri.EscapeDataString(projectId)}/items/{Uri.EscapeDataString(itemId)}/versions";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("data", out var dataArray) && dataArray.ValueKind == JsonValueKind.Array)
            {
                var latestVersion = dataArray.EnumerateArray().FirstOrDefault();
                if (latestVersion.ValueKind != JsonValueKind.Undefined)
                {
                    if (latestVersion.TryGetProperty("relationships", out var rels) &&
                        rels.TryGetProperty("storage", out var storage) &&
                        storage.TryGetProperty("meta", out var meta) &&
                        meta.TryGetProperty("link", out var link) &&
                        link.TryGetProperty("href", out var hrefProp))
                    {
                        return hrefProp.GetString();
                    }

                    if (latestVersion.TryGetProperty("relationships", out var rels2) &&
                        rels2.TryGetProperty("storage", out var storage2) &&
                        storage2.TryGetProperty("data", out var dataObj) &&
                        dataObj.TryGetProperty("id", out var idProp))
                    {
                        string storageUrn = idProp.GetString() ?? string.Empty;
                        if (storageUrn.StartsWith("urn:adsk.objects:os.object:", StringComparison.OrdinalIgnoreCase))
                        {
                            string path = storageUrn.Substring("urn:adsk.objects:os.object:".Length);
                            return $"{BaseUrl}/oss/v2/buckets/{path}";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in GetLatestVersionDownloadUrlAsync for item '{itemId}'", ex);
        }

        return null;
    }

    /// <summary>
    /// Downloads an ACC .rfa file using its storage download URL and saves it to local temporary storage.
    /// Uses FamilyFileManager to enforce Path.GetFullPath validation.
    /// </summary>
    public static async Task<string> DownloadAccFamilyFileAsync(
        string accessToken,
        string downloadUrl,
        string rawFileName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(downloadUrl)) throw new ArgumentException("Download URL is required.", nameof(downloadUrl));

        var request = new HttpRequestMessage(HttpMethod.Get, downloadUrl);
        if (!string.IsNullOrWhiteSpace(accessToken) && !downloadUrl.Contains("X-Amz-Signature"))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        using var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();

        using var memoryStream = new MemoryStream();
        await response.Content.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        string localPath = FamilyFileManager.CreateFamilyLocalFile(memoryStream, rawFileName);
        TelemetryLogger.LogInfo($"[AutodeskDocsService] Downloaded ACC family '{rawFileName}' to '{localPath}'");
        return localPath;
    }

    /// <summary>
    /// GET https://developer.api.autodesk.com/data/v1/projects/{projectId}/folders/{folderId}/contents
    /// Retrieves subfolders and CAD item files (.dwg, .dxf, .axm, .sat, .dgn, .obj, .3dm, .skp, .stl) in a specific folder.
    /// </summary>
    public static async Task<(List<AccFolderModel> Subfolders, List<AccItemModel> CadItems)> GetFolderCadContentsAsync(
        string accessToken,
        string projectId,
        string folderId,
        CancellationToken cancellationToken = default)
    {
        var subfolders = new List<AccFolderModel>();
        var cadItems = new List<AccItemModel>();

        if (string.IsNullOrWhiteSpace(accessToken) || string.IsNullOrWhiteSpace(projectId) || string.IsNullOrWhiteSpace(folderId))
            return (subfolders, cadItems);

        var cadExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".dwg", ".dxf", ".axm", ".sat", ".dgn", ".obj", ".3dm", ".skp", ".stl"
        };

        try
        {
            string url = $"{BaseUrl}/data/v1/projects/{Uri.EscapeDataString(projectId)}/folders/{Uri.EscapeDataString(folderId)}/contents";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                TelemetryLogger.LogWarning($"[AutodeskDocsService] GetFolderCadContentsAsync failed for folder '{folderId}': {response.StatusCode}");
                return (subfolders, cadItems);
            }

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("data", out var dataArray) && dataArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var element in dataArray.EnumerateArray())
                {
                    string type = element.GetProperty("type").GetString() ?? string.Empty;
                    string id = element.GetProperty("id").GetString() ?? string.Empty;
                    var attributes = element.GetProperty("attributes");

                    if (type.Equals("folders", StringComparison.OrdinalIgnoreCase))
                    {
                        string folderName = attributes.GetProperty("displayName").GetString() ?? "Subfolder";
                        subfolders.Add(new AccFolderModel { Id = id, Name = folderName, HasChildren = true });
                    }
                    else if (type.Equals("items", StringComparison.OrdinalIgnoreCase))
                    {
                        string displayName = attributes.GetProperty("displayName").GetString() ?? string.Empty;
                        string ext = Path.GetExtension(displayName);
                        if (cadExtensions.Contains(ext))
                        {
                            long size = attributes.TryGetProperty("storageSize", out var szProp) ? szProp.GetInt64() : 0;
                            DateTime? lastMod = null;
                            if (attributes.TryGetProperty("lastModifiedTime", out var lmtProp) &&
                                DateTime.TryParse(lmtProp.GetString(), out var dt))
                            {
                                lastMod = dt;
                            }

                            cadItems.Add(new AccItemModel
                            {
                                Id = id,
                                DisplayName = displayName,
                                ContentLength = size,
                                LastModified = lastMod
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error in GetFolderCadContentsAsync for folder '{folderId}'", ex);
        }

        return (subfolders, cadItems);
    }
}
