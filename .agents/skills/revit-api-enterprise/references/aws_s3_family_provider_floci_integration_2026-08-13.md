# AWS S3 Cloud Family Provider & Floci LocalStack Integration Pattern

## 1. Overview
This reference guide documents the architectural pattern for integrating **AWS S3** as a family source provider (`IFamilyProvider`) in Revit add-ins, supporting both local Docker development (**Floci / LocalStack** at `http://localhost:4566`) and production **AWS S3 Real** (`https://s3.amazonaws.com`).

---

## 2. Core Components

### A. Factory & Path Style Addressing (`S3ClientFactory.cs`)
Floci and LocalStack require path-style S3 addressing (`http://localhost:4566/bucket-name/file.rfa`) rather than virtual-host addressing. `S3ClientFactory` dynamically configures `ForcePathStyle = true` whenever a local endpoint is detected:

```csharp
using Amazon;
using Amazon.S3;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class S3ClientFactory
{
    public static IAmazonS3 Create(FamilySourceItemModel model)
    {
        return Create(model.EndpointUrl, model.Region, model.AccessKey, model.SecretKey);
    }

    public static IAmazonS3 Create(string endpointUrl, string regionName, string accessKey, string secretKey)
    {
        string endpoint = string.IsNullOrWhiteSpace(endpointUrl) ? "https://s3.amazonaws.com" : endpointUrl.Trim();
        string region = string.IsNullOrWhiteSpace(regionName) ? "eu-west-1" : regionName.Trim();

        bool isLocalEndpoint = endpoint.Contains("localhost") || endpoint.Contains("127.0.0.1") || endpoint.Contains(":4566");

        var config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.GetBySystemName(region),
            ServiceURL = endpoint,
            ForcePathStyle = isLocalEndpoint
        };

        string key = string.IsNullOrWhiteSpace(accessKey) ? "test" : accessKey;
        string secret = string.IsNullOrWhiteSpace(secretKey) ? "test" : secretKey;

        return new AmazonS3Client(key, secret, config);
    }
}
```

---

### B. DPAPI Encryption for Cloud Credentials
Sensitive cloud keys (`AccessKey`, `SecretKey`) must never be written to JSON configuration files in plain text. Use Windows DPAPI via `SecurityUtils`:

```csharp
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
```

---

### C. Local Cache & 3D Thumbnail Resolution
To ensure WPF `FamilyThumbnailService` and `RfaMetadataExtractor` can extract embedded 3D PNG previews, `AwsS3StorageFamilyProvider` pre-downloads objects to `%TEMP%\TransferPlus_AwsCache\` and sets `ImagePreviewUrl` to the local `cachedFilePath`:

```csharp
string cachedFilePath = Path.Combine(cacheDir, Path.GetFileName(s3Obj.ObjectKey));
if (!File.Exists(cachedFilePath))
{
    string downloaded = await AwsS3StorageService.DownloadFamilyBlobAsync(_sourceItem, s3Obj.ObjectKey, cacheDir);
    if (File.Exists(downloaded)) cachedFilePath = downloaded;
}

result.Add(new FamilyItemModel
{
    Name = s3Obj.FamilyName,
    CategoryName = categoryName,
    SourceName = ProviderName,
    StatusMessage = $"AWS S3 ({s3Obj.FormattedSize})",
    ImagePreviewUrl = File.Exists(cachedFilePath) ? cachedFilePath : s3Obj.ObjectKey,
    RevitVersion = string.IsNullOrWhiteSpace(ver) ? "AWS S3 Cloud" : ver,
    Symbols = symbols
});
```

---

## 3. Benefits & Enterprise Value
- **Zero-Cost Local Prototyping**: Developers can test S3 bucket operations locally with Floci (`http://localhost:4566`) using `test`/`test` credentials without incurring AWS fees or needing internet connectivity.
- **Seamless Production Switching**: Changing `EndpointUrl` to `https://s3.amazonaws.com` switches instantly to production AWS S3.
- **Decoupled Architecture**: Follows `IFamilyProvider` abstraction, making AWS S3 indistinguishable from local directories or Azure Blob containers in the UI.
