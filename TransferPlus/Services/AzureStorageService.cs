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
}
