using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels;

public enum AccNodeType
{
    Hub,
    Project,
    Folder
}

public partial class AccTreeNodeModel : ObservableObject
{
    [ObservableProperty]
    private string _id = string.Empty;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private AccNodeType _nodeType = AccNodeType.Folder;

    [ObservableProperty]
    private string _hubId = string.Empty;

    [ObservableProperty]
    private string _projectId = string.Empty;

    [ObservableProperty]
    private ObservableCollection<AccTreeNodeModel> _children = new();

    [ObservableProperty]
    private bool _isExpanded;

    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    private bool _isLoading;
}

public partial class AutodeskDocsSourceViewModel : ObservableObject
{
    [ObservableProperty]
    private string _sourceName = string.Empty;

    [ObservableProperty]
    private string _clientId = string.Empty;

    [ObservableProperty]
    private string _accessToken = string.Empty;

    [ObservableProperty]
    private string _refreshToken = string.Empty;

    [ObservableProperty]
    private string _statusMessage = "Click 'Sign In with Autodesk' to access your ACC / BIM 360 projects.";

    [ObservableProperty]
    private string _connectedUserName = string.Empty;

    [ObservableProperty]
    private bool _isConnected;

    [ObservableProperty]
    private bool _isAuthenticating;

    [ObservableProperty]
    private bool _isActive = true;

    [ObservableProperty]
    private ObservableCollection<AccTreeNodeModel> _treeNodes = new();

    [ObservableProperty]
    private AccTreeNodeModel? _selectedNode;

    private string _editingId = Guid.NewGuid().ToString();

    public AutodeskDocsSourceViewModel()
    {
    }

    public AutodeskDocsSourceViewModel(FamilySourceItemModel model)
    {
        if (model == null) return;
        _editingId = model.Id;
        SourceName = model.Name;
        ClientId = model.ClientId;
        AccessToken = model.AccessToken;
        RefreshToken = model.RefreshToken;
        IsActive = model.IsActive;

        if (!string.IsNullOrWhiteSpace(AccessToken) || !string.IsNullOrWhiteSpace(RefreshToken))
        {
            _ = ConnectAndLoadHubsAsync();
        }
    }

    public AutodeskDocsSourceViewModel(CadSourceItemModel model)
    {
        if (model == null) return;
        _editingId = model.Id;
        SourceName = model.Name;
        ClientId = model.ClientId;
        AccessToken = model.AccessToken;
        RefreshToken = model.RefreshToken;
        IsActive = model.IsActive;

        if (!string.IsNullOrWhiteSpace(AccessToken) || !string.IsNullOrWhiteSpace(RefreshToken))
        {
            _ = ConnectAndLoadHubsAsync();
        }
    }

    [RelayCommand]
    private async Task SignInWithAutodeskAsync()
    {
        string effectiveClientId = string.IsNullOrWhiteSpace(ClientId) ? AutodeskDocsService.DefaultClientId : ClientId;

        if (string.IsNullOrWhiteSpace(effectiveClientId) || effectiveClientId.Equals("YOUR_AUTODESK_APS_CLIENT_ID_HERE", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show(
                "La aplicación está preparada para conectar con Autodesk Construction Cloud (ACC).\n\n" +
                "Cuando obtengas el Client ID oficial de TransferPlus al publicar la aplicación en el portal de desarrolladores de Autodesk (https://aps.autodesk.com/myapps), introdúcelo en la sección 'Advanced Developer Settings' o reemplaza la constante 'DefaultClientId' en 'AutodeskDocsService.cs'.\n\n" +
                "Una vez configurado, este botón abrirá automáticamente el inicio de sesión oficial de Autodesk para todos los usuarios.",
                "Autodesk APS Client ID Requerido",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            return;
        }

        IsAuthenticating = true;
        StatusMessage = "Opening Autodesk Sign-In page in browser...";

        try
        {
            var (codeVerifier, codeChallenge) = AutodeskDocsService.GeneratePkce();
            string state = Guid.NewGuid().ToString("N");
            string authUrl = AutodeskDocsService.GetOAuthAuthorizationUrl(
                effectiveClientId,
                AutodeskDocsService.DefaultRedirectUri,
                state,
                codeChallenge);

            // Open official Autodesk OAuth login page in default browser
            Process.Start(new ProcessStartInfo
            {
                FileName = authUrl,
                UseShellExecute = true
            });

            StatusMessage = "Waiting for login completion in browser...";

            // Listen for loopback callback code
            string? code = await AutodeskDocsService.CaptureOAuthCodeViaLoopbackAsync(8989);
            if (string.IsNullOrWhiteSpace(code))
            {
                StatusMessage = "Sign-in was cancelled or timed out.";
                return;
            }

            StatusMessage = "Exchanging authorization code...";
            var tokenResult = await AutodeskDocsService.ExchangeCodeForTokensAsync(
                code,
                codeVerifier,
                effectiveClientId,
                AutodeskDocsService.DefaultRedirectUri);

            if (tokenResult.Success)
            {
                AccessToken = tokenResult.AccessToken;
                RefreshToken = tokenResult.RefreshToken;
                await ConnectAndLoadHubsAsync();
            }
            else
            {
                StatusMessage = $"Authentication failed: {tokenResult.ErrorMessage}";
                IsConnected = false;
            }
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in SignInWithAutodeskAsync", ex);
            StatusMessage = $"Sign-in error: {ex.Message}";
            IsConnected = false;
        }
        finally
        {
            IsAuthenticating = false;
        }
    }

    [RelayCommand]
    private void LogOut()
    {
        AccessToken = string.Empty;
        RefreshToken = string.Empty;
        ConnectedUserName = string.Empty;
        IsConnected = false;
        TreeNodes.Clear();
        SelectedNode = null;
        StatusMessage = "Logged out. Click 'Sign In with Autodesk' to log in with a different account.";
    }

    [RelayCommand]
    public async Task ConnectAndLoadHubsAsync()
    {
        if (string.IsNullOrWhiteSpace(AccessToken) && string.IsNullOrWhiteSpace(RefreshToken))
        {
            StatusMessage = "Not connected. Click 'Sign In with Autodesk Account' above.";
            IsConnected = false;
            return;
        }

        StatusMessage = "Connecting to Autodesk Construction Cloud (ACC)...";
        IsConnected = false;
        TreeNodes.Clear();

        try
        {
            // If AccessToken is empty or expired, attempt refresh
            if (string.IsNullOrWhiteSpace(AccessToken) && !string.IsNullOrWhiteSpace(RefreshToken))
            {
                var refreshRes = await AutodeskDocsService.RefreshTokenAsync(RefreshToken);
                if (refreshRes.Success)
                {
                    AccessToken = refreshRes.AccessToken;
                    RefreshToken = refreshRes.RefreshToken;
                }
                else
                {
                    StatusMessage = $"Token refresh failed: {refreshRes.ErrorMessage}";
                    return;
                }
            }

            // Fetch user profile name/email
            var profile = await AutodeskDocsService.GetUserProfileAsync(AccessToken);
            if (profile != null)
            {
                ConnectedUserName = $"{profile.UserName} ({profile.EmailId})";
            }
            else
            {
                ConnectedUserName = "Autodesk Account";
            }

            var hubs = await AutodeskDocsService.GetHubsAsync(AccessToken);
            if (hubs.Count == 0)
            {
                StatusMessage = $"Connected as {ConnectedUserName}, but 0 Hubs were returned.";
                IsConnected = true;
                return;
            }

            foreach (var hub in hubs)
            {
                var hubNode = new AccTreeNodeModel
                {
                    Id = hub.Id,
                    Name = $"🏢 {hub.Name}",
                    NodeType = AccNodeType.Hub,
                    HubId = hub.Id
                };

                hubNode.Children.Add(new AccTreeNodeModel { Name = "Loading projects..." });
                TreeNodes.Add(hubNode);
            }

            IsConnected = true;
            StatusMessage = $"Connected as {ConnectedUserName}! Loaded {hubs.Count} Hub(s).";
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error in ConnectAndLoadHubsAsync", ex);
            StatusMessage = $"Connection error: {ex.Message}";
            IsConnected = false;
        }
    }

    public async Task OnNodeExpandedAsync(AccTreeNodeModel node)
    {
        if (node == null || node.Children.Count == 0) return;
        if (node.Children.Count == 1 && node.Children[0].Name.StartsWith("Loading"))
        {
            node.IsLoading = true;
            node.Children.Clear();

            try
            {
                if (node.NodeType == AccNodeType.Hub)
                {
                    var projects = await AutodeskDocsService.GetProjectsAsync(AccessToken, node.HubId);
                    foreach (var prj in projects)
                    {
                        var prjNode = new AccTreeNodeModel
                        {
                            Id = prj.Id,
                            Name = $"🏗️ {prj.Name}",
                            NodeType = AccNodeType.Project,
                            HubId = node.HubId,
                            ProjectId = prj.Id
                        };
                        prjNode.Children.Add(new AccTreeNodeModel { Name = "Loading folders..." });
                        node.Children.Add(prjNode);
                    }
                }
                else if (node.NodeType == AccNodeType.Project)
                {
                    var rootFolder = await AutodeskDocsService.GetRootFolderAsync(AccessToken, node.ProjectId);
                    if (rootFolder != null)
                    {
                        var rootNode = new AccTreeNodeModel
                        {
                            Id = rootFolder.Id,
                            Name = $"📁 {rootFolder.Name}",
                            NodeType = AccNodeType.Folder,
                            HubId = node.HubId,
                            ProjectId = node.ProjectId
                        };

                        var (subfolders, rfaItems) = await AutodeskDocsService.GetFolderContentsAsync(AccessToken, node.ProjectId, rootFolder.Id);
                        foreach (var sub in subfolders)
                        {
                            var subNode = new AccTreeNodeModel
                            {
                                Id = sub.Id,
                                Name = $"📁 {sub.Name}",
                                NodeType = AccNodeType.Folder,
                                HubId = node.HubId,
                                ProjectId = node.ProjectId
                            };
                            subNode.Children.Add(new AccTreeNodeModel { Name = "Loading subfolders..." });
                            rootNode.Children.Add(subNode);
                        }

                        node.Children.Add(rootNode);
                    }
                }
                else if (node.NodeType == AccNodeType.Folder)
                {
                    var (subfolders, rfaItems) = await AutodeskDocsService.GetFolderContentsAsync(AccessToken, node.ProjectId, node.Id);
                    foreach (var sub in subfolders)
                    {
                        var subNode = new AccTreeNodeModel
                        {
                            Id = sub.Id,
                            Name = $"📁 {sub.Name}",
                            NodeType = AccNodeType.Folder,
                            HubId = node.HubId,
                            ProjectId = node.ProjectId
                        };
                        subNode.Children.Add(new AccTreeNodeModel { Name = "Loading subfolders..." });
                        node.Children.Add(subNode);
                    }
                }
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error expanding node '{node.Name}'", ex);
            }
            finally
            {
                node.IsLoading = false;
            }
        }
    }

    public void OnNodeSelected(AccTreeNodeModel node)
    {
        if (node == null) return;
        SelectedNode = node;

        if (node.NodeType == AccNodeType.Folder)
        {
            string cleanFolderName = node.Name.Replace("📁 ", "").Trim();
            if (string.IsNullOrWhiteSpace(SourceName))
            {
                SourceName = $"ACC: {cleanFolderName}";
            }
        }
    }

    [RelayCommand]
    private void Ok(Window? window)
    {
        if (SelectedNode == null || SelectedNode.NodeType != AccNodeType.Folder)
        {
            MessageBox.Show("Please select a target folder (📁) in the tree view to use as the family library source.",
                "Select Folder", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        if (string.IsNullOrWhiteSpace(SourceName))
        {
            string cleanFolderName = SelectedNode.Name.Replace("📁 ", "").Trim();
            SourceName = $"ACC: {cleanFolderName}";
        }

        if (window != null)
        {
            window.DialogResult = true;
            window.Close();
        }
    }

    [RelayCommand]
    private void Cancel(Window? window)
    {
        if (window != null)
        {
            window.DialogResult = false;
            window.Close();
        }
    }

    public FamilySourceItemModel ToModel(string? idOverride = null)
    {
        string cleanFolderName = SelectedNode?.Name.Replace("📁 ", "").Trim() ?? "Project Files";
        return new FamilySourceItemModel
        {
            Id = idOverride ?? _editingId,
            Name = SourceName,
            SourceType = FamilySourceType.AutodeskDocs,
            HubId = SelectedNode?.HubId ?? string.Empty,
            ProjectId = SelectedNode?.ProjectId ?? string.Empty,
            FolderId = SelectedNode?.Id ?? string.Empty,
            FolderName = cleanFolderName,
            ClientId = ClientId,
            AccessToken = AccessToken,
            RefreshToken = RefreshToken,
            IsActive = IsActive
        };
    }

    public CadSourceItemModel ToCadModel(string? idOverride = null)
    {
        string cleanFolderName = SelectedNode?.Name.Replace("📁 ", "").Trim() ?? "Project Files";
        return new CadSourceItemModel
        {
            Id = idOverride ?? _editingId,
            Name = SourceName,
            SourceType = CadSourceType.AutodeskDocs,
            HubId = SelectedNode?.HubId ?? string.Empty,
            ProjectId = SelectedNode?.ProjectId ?? string.Empty,
            FolderId = SelectedNode?.Id ?? string.Empty,
            FolderName = cleanFolderName,
            ClientId = ClientId,
            AccessToken = AccessToken,
            RefreshToken = RefreshToken,
            IsActive = IsActive
        };
    }
}
