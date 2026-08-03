using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TransferPlus.Services;

namespace TransferPlus.Models;

public enum FamilySourceType
{
    Directory,
    AzureStorage
}

public class FamilySourceItemModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public FamilySourceType SourceType { get; set; } = FamilySourceType.Directory;
    public string Path { get; set; } = string.Empty;
    public string EndpointUrl { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string ContainerName { get; set; } = string.Empty;
    public string RootPath { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

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
            if (SourceType == FamilySourceType.Directory)
            {
                return string.IsNullOrWhiteSpace(Path) ? "(No Directory)" : Path;
            }

            var parts = new List<string>();
            if (!string.IsNullOrWhiteSpace(ContainerName)) parts.Add(ContainerName);
            if (!string.IsNullOrWhiteSpace(RootPath)) parts.Add(RootPath);
            var subPath = string.Join("/", parts);
            return string.IsNullOrWhiteSpace(subPath) ? "Azure Storage" : $"Azure: {subPath}";
        }
    }
}
