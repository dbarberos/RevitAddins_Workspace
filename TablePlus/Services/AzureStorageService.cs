using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TablePlus.Models;

namespace TablePlus.Services;

public class AzureSpreadsheetBlobModel
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

public static class AzureStorageService
{
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
    /// Queries the Azure Blob Storage container for available spreadsheet files (.xlsx, .xlsm, .xls, .csv).
    /// </summary>
    public static async Task<List<AzureSpreadsheetBlobModel>> GetAvailableSpreadsheetsAsync(
        string connectionString,
        string containerName,
        string rootPath = "",
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(containerName))
        {
            return new List<AzureSpreadsheetBlobModel>();
        }

        var spreadsheetExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".xlsx", ".xlsm", ".xls", ".csv"
        };

        return await Task.Run(() =>
        {
            var resultList = new List<AzureSpreadsheetBlobModel>();
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
                    if (!spreadsheetExtensions.Contains(ext)) continue;

                    var blobClient = containerClient.GetBlobClient(blob.Name);
                    string rawName = Path.GetFileNameWithoutExtension(blob.Name);

                    resultList.Add(new AzureSpreadsheetBlobModel
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

                TelemetryLogger.LogInfo($"Retrieved {resultList.Count} spreadsheet files from Azure Storage container '{containerName}'");
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error retrieving spreadsheets from Azure container '{containerName}'", ex);
            }

            return resultList;
        }, cancellationToken);
    }

    /// <summary>
    /// Downloads an Azure spreadsheet blob to local temporary path safely.
    /// </summary>
    public static async Task<string> DownloadSpreadsheetBlobAsync(
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

        string spreadsheetFileName = Path.GetFileName(blobName);
        string localTempFilePath = TableFileManager.CreateTableLocalFile(memoryStream, spreadsheetFileName);

        TelemetryLogger.LogInfo($"Azure spreadsheet '{blobName}' downloaded safely to: {localTempFilePath}");
        return localTempFilePath;
    }
}
