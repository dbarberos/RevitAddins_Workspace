using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TransferPlus.Services;

namespace TransferPlus.Models;

public enum CadSourceType
{
    Directory,
    AzureStorage,
    AutodeskDocs,
    AwsS3
}

public class CadSourceItemModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public CadSourceType SourceType { get; set; } = CadSourceType.Directory;
    public string Path { get; set; } = string.Empty;
    public string EndpointUrl { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string ContainerName { get; set; } = string.Empty;
    public string RootPath { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // AWS S3 Specific Fields
    public string BucketName { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string EncryptedAccessKey { get; set; } = string.Empty;
    public string EncryptedSecretKey { get; set; } = string.Empty;

    [JsonIgnore]
    public string AccessKey
    {
        get => string.IsNullOrEmpty(EncryptedAccessKey) ? string.Empty : SecurityUtils.DecryptString(EncryptedAccessKey);
        set => EncryptedAccessKey = string.IsNullOrEmpty(value) ? string.Empty : SecurityUtils.EncryptString(value);
    }

    [JsonIgnore]
    public string SecretKey
    {
        get => string.IsNullOrEmpty(EncryptedSecretKey) ? string.Empty : SecurityUtils.DecryptString(EncryptedSecretKey);
        set => EncryptedSecretKey = string.IsNullOrEmpty(value) ? string.Empty : SecurityUtils.EncryptString(value);
    }

    // Autodesk Docs (APS / ACC) Specific Fields
    public string HubId { get; set; } = string.Empty;
    public string HubName { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public string FolderId { get; set; } = string.Empty;
    public string FolderName { get; set; } = string.Empty;

    public string EncryptedRefreshToken { get; set; } = string.Empty;
    public string EncryptedAccessToken { get; set; } = string.Empty;

    [JsonIgnore]
    public string RefreshToken
    {
        get => string.IsNullOrEmpty(EncryptedRefreshToken) ? string.Empty : SecurityUtils.DecryptString(EncryptedRefreshToken);
        set => EncryptedRefreshToken = string.IsNullOrEmpty(value) ? string.Empty : SecurityUtils.EncryptString(value);
    }

    [JsonIgnore]
    public string AccessToken
    {
        get => string.IsNullOrEmpty(EncryptedAccessToken) ? string.Empty : SecurityUtils.DecryptString(EncryptedAccessToken);
        set => EncryptedAccessToken = string.IsNullOrEmpty(value) ? string.Empty : SecurityUtils.EncryptString(value);
    }

    /// <summary>
    /// DPAPI encrypted connection string for JSON persistence.
    /// </summary>
    public string EncryptedConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// Decrypted in-memory connection string.
    /// </summary>
    [JsonIgnore]
    public string ConnectionString
    {
        get => string.IsNullOrEmpty(EncryptedConnectionString) ? string.Empty : SecurityUtils.DecryptString(EncryptedConnectionString);
        set => EncryptedConnectionString = string.IsNullOrEmpty(value) ? string.Empty : SecurityUtils.EncryptString(value);
    }

    [JsonIgnore]
    public string SourceDescription
    {
        get
        {
            if (SourceType == CadSourceType.Directory)
            {
                return string.IsNullOrWhiteSpace(Path) ? "(No Directory)" : Path;
            }
            if (SourceType == CadSourceType.AutodeskDocs)
            {
                var parts = new List<string>();
                if (!string.IsNullOrWhiteSpace(ProjectName)) parts.Add(ProjectName);
                if (!string.IsNullOrWhiteSpace(FolderName)) parts.Add(FolderName);
                var accPath = string.Join(" / ", parts);
                return string.IsNullOrWhiteSpace(accPath) ? "Autodesk Docs (APS)" : $"ACC: {accPath}";
            }
            if (SourceType == CadSourceType.AwsS3)
            {
                var awsParts = new List<string>();
                if (!string.IsNullOrWhiteSpace(BucketName)) awsParts.Add(BucketName);
                if (!string.IsNullOrWhiteSpace(RootPath)) awsParts.Add(RootPath);
                var awsSubPath = string.Join("/", awsParts);
                return string.IsNullOrWhiteSpace(awsSubPath) ? "AWS S3" : $"AWS S3: {awsSubPath}";
            }

            var azureParts = new List<string>();
            if (!string.IsNullOrWhiteSpace(ContainerName)) azureParts.Add(ContainerName);
            if (!string.IsNullOrWhiteSpace(RootPath)) azureParts.Add(RootPath);
            var azureSubPath = string.Join("/", azureParts);
            return string.IsNullOrWhiteSpace(azureSubPath) ? "Azure Storage" : $"Azure: {azureSubPath}";
        }
    }
}
