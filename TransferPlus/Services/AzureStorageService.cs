using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class AzureStorageService
{
    private static readonly Regex BackupRegex = new(@"\.\d{4}\.rfa$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Tests connectivity to an Azure Blob Storage container.
    /// </summary>
    public static async Task<(bool Success, string Message)> TestConnectionAsync(
        string connectionString,
        string containerName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            return (false, "Connection String is empty.");

        if (string.IsNullOrWhiteSpace(containerName))
            return (false, "Container Name is empty.");

        try
        {
            var containerClient = new BlobContainerClient(connectionString, containerName);
            bool exists = await containerClient.ExistsAsync(cancellationToken);
            if (!exists)
            {
                return (false, $"Container '{containerName}' does not exist on target storage account.");
            }

            return (true, "Successfully connected to Azure Blob Storage!");
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error testing Azure Storage connection", ex);
            return (false, $"Connection error: {ex.Message}");
        }
    }

    /// <summary>
    /// Queries the Azure Blob Storage container for available Revit .rfa family files.
    /// Filters out backup files matching *.0001.rfa.
    /// </summary>
    public static async Task<List<AzureFamilyBlobModel>> GetAvailableFamiliesAsync(
        string connectionString,
        string containerName,
        string rootPath = "",
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(containerName))
        {
            return new List<AzureFamilyBlobModel>();
        }

        return await Task.Run(() =>
        {
            var resultList = new List<AzureFamilyBlobModel>();
            try
            {
                var containerClient = new BlobContainerClient(connectionString, containerName);
                string prefix = string.IsNullOrWhiteSpace(rootPath) ? string.Empty : (rootPath.EndsWith("/") ? rootPath : rootPath + "/");

                var pageableBlobs = containerClient.GetBlobs(prefix: string.IsNullOrEmpty(prefix) ? null : prefix, cancellationToken: cancellationToken);
                foreach (BlobItem blob in pageableBlobs)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (string.IsNullOrWhiteSpace(blob.Name)) continue;

                    // Only include .rfa files
                    if (!blob.Name.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase)) continue;

                    // Exclude Revit backup files (e.g. MyFamily.0001.rfa)
                    if (BackupRegex.IsMatch(blob.Name)) continue;

                    var blobClient = containerClient.GetBlobClient(blob.Name);
                    string rawName = Path.GetFileNameWithoutExtension(blob.Name);

                    resultList.Add(new AzureFamilyBlobModel
                    {
                        BlobName = blob.Name,
                        FamilyName = rawName,
                        ContentLength = blob.Properties.ContentLength ?? 0,
                        LastModified = blob.Properties.LastModified,
                        ContainerName = containerName,
                        FullUri = blobClient.Uri.AbsoluteUri
                    });
                }

                TelemetryLogger.LogInfo($"Recuperadas {resultList.Count} familias .rfa de Azure Storage container '{containerName}'");
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al obtener familias .rfa del contenedor Azure '{containerName}'", ex);
            }

            return resultList;
        }, cancellationToken);
    }

    /// <summary>
    /// Synchronously downloads an Azure .rfa blob to a local temporary path.
    /// Eliminates async SynchronizationContext deadlocks when invoked from Revit UI thread.
    /// Uses FamilyFileManager to enforce Path.GetFullPath validation.
    /// </summary>
    public static string DownloadFamilyBlob(
        string connectionString,
        string containerName,
        string blobName)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("Connection string is required.", nameof(connectionString));
        if (string.IsNullOrWhiteSpace(containerName)) throw new ArgumentException("Container name is required.", nameof(containerName));
        if (string.IsNullOrWhiteSpace(blobName)) throw new ArgumentException("Blob name is required.", nameof(blobName));

        var containerClient = new BlobContainerClient(connectionString, containerName);
        var blobClient = containerClient.GetBlobClient(blobName);

        using var memoryStream = new MemoryStream();
        blobClient.DownloadTo(memoryStream);
        memoryStream.Position = 0;

        TelemetryLogger.LogInfo($"AzureStorageService: Blob '{blobName}' descargado en memoria ({memoryStream.Length} bytes).");

        string familyFileName = Path.GetFileName(blobName);
        string localTempFilePath = FamilyFileManager.CreateFamilyLocalFile(memoryStream, familyFileName);

        TelemetryLogger.LogInfo($"Familia de Azure '{blobName}' descargada en: {localTempFilePath}");
        return localTempFilePath;
    }

    /// <summary>
    /// Asynchronously downloads an Azure .rfa blob to a local temporary path.
    /// Uses FamilyFileManager to enforce Path.GetFullPath validation.
    /// </summary>
    public static async Task<string> DownloadFamilyBlobAsync(
        string connectionString,
        string containerName,
        string blobName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("Connection string is required.", nameof(connectionString));
        if (string.IsNullOrWhiteSpace(containerName)) throw new ArgumentException("Container name is required.", nameof(containerName));
        if (string.IsNullOrWhiteSpace(blobName)) throw new ArgumentException("Blob name is required.", nameof(blobName));

        var containerClient = new BlobContainerClient(connectionString, containerName);
        var blobClient = containerClient.GetBlobClient(blobName);

        using var memoryStream = new MemoryStream();
        await blobClient.DownloadToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
        memoryStream.Position = 0;

        string familyFileName = Path.GetFileName(blobName);
        string localTempFilePath = FamilyFileManager.CreateFamilyLocalFile(memoryStream, familyFileName);

        TelemetryLogger.LogInfo($"Familia de Azure '{blobName}' descargada asíncronamente en: {localTempFilePath}");
        return localTempFilePath;
    }

    /// <summary>
    /// Queries the Azure Blob Storage container for available CAD drawing files (.dwg, .dxf, .axm, .sat, .dgn, .obj, .3dm, .skp, .stl).
    /// </summary>
    public static async Task<List<AzureCadBlobModel>> GetAvailableCadBlobsAsync(
        string connectionString,
        string containerName,
        string rootPath = "",
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(containerName))
        {
            return new List<AzureCadBlobModel>();
        }

        var cadExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".dwg", ".dxf", ".axm", ".sat", ".dgn", ".obj", ".3dm", ".skp", ".stl"
        };

        return await Task.Run(() =>
        {
            var resultList = new List<AzureCadBlobModel>();
            try
            {
                var containerClient = new BlobContainerClient(connectionString, containerName);
                string prefix = string.IsNullOrWhiteSpace(rootPath) ? string.Empty : (rootPath.EndsWith("/") ? rootPath : rootPath + "/");

                var pageableBlobs = containerClient.GetBlobs(prefix: string.IsNullOrEmpty(prefix) ? null : prefix, cancellationToken: cancellationToken);
                foreach (BlobItem blob in pageableBlobs)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (string.IsNullOrWhiteSpace(blob.Name)) continue;

                    string ext = Path.GetExtension(blob.Name);
                    if (!cadExtensions.Contains(ext)) continue;

                    var blobClient = containerClient.GetBlobClient(blob.Name);
                    string rawName = Path.GetFileNameWithoutExtension(blob.Name);

                    resultList.Add(new AzureCadBlobModel
                    {
                        BlobName = blob.Name,
                        FileName = rawName,
                        Extension = ext.TrimStart('.').ToLowerInvariant(),
                        ContentLength = blob.Properties.ContentLength ?? 0,
                        LastModified = blob.Properties.LastModified,
                        ContainerName = containerName,
                        FullUri = blobClient.Uri.AbsoluteUri
                    });
                }

                TelemetryLogger.LogInfo($"Recuperados {resultList.Count} archivos CAD de Azure Storage container '{containerName}'");
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al obtener archivos CAD del contenedor Azure '{containerName}'", ex);
            }

            return resultList;
        }, cancellationToken);
    }

    /// <summary>
    /// Downloads an Azure CAD blob to a local temporary path.
    /// </summary>
    public static string DownloadCadBlob(
        string connectionString,
        string containerName,
        string blobName)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("Connection string is required.", nameof(connectionString));
        if (string.IsNullOrWhiteSpace(containerName)) throw new ArgumentException("Container name is required.", nameof(containerName));
        if (string.IsNullOrWhiteSpace(blobName)) throw new ArgumentException("Blob name is required.", nameof(blobName));

        var containerClient = new BlobContainerClient(connectionString, containerName);
        var blobClient = containerClient.GetBlobClient(blobName);

        using var memoryStream = new MemoryStream();
        blobClient.DownloadTo(memoryStream);
        memoryStream.Position = 0;

        string cadFileName = Path.GetFileName(blobName);
        string localTempFilePath = FamilyFileManager.CreateFamilyLocalFile(memoryStream, cadFileName);

        TelemetryLogger.LogInfo($"Archivo CAD de Azure '{blobName}' descargado en: {localTempFilePath}");
        return localTempFilePath;
    }
}

public class AzureCadBlobModel
{
    public string BlobName { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public long ContentLength { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public string ContainerName { get; set; } = string.Empty;
    public string FullUri { get; set; } = string.Empty;

    public string FormattedSize
    {
        get
        {
            if (ContentLength < 1024) return $"{ContentLength} B";
            if (ContentLength < 1024 * 1024) return $"{ContentLength / 1024.0:F1} KB";
            return $"{ContentLength / (1024.0 * 1024.0):F1} MB";
        }
    }
}
