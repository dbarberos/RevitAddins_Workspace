using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using TransferPlus.Models;

namespace TransferPlus.Services;

public class AwsS3FamilyBlobModel
{
    public string ObjectKey { get; set; } = string.Empty;
    public string FamilyName { get; set; } = string.Empty;
    public long SizeBytes { get; set; }
    public DateTime LastModified { get; set; }

    public string FormattedSize
    {
        get
        {
            if (SizeBytes < 1024) return $"{SizeBytes} B";
            if (SizeBytes < 1024 * 1024) return $"{SizeBytes / 1024.0:F1} KB";
            return $"{SizeBytes / (1024.0 * 1024.0):F1} MB";
        }
    }
}

public static class AwsS3StorageService
{
    public static async Task<(bool Success, string Message, bool IsFloci)> TestConnectionAsync(FamilySourceItemModel model)
    {
        string endpoint = model.EndpointUrl ?? string.Empty;
        bool isFloci = endpoint.Contains("localhost") || endpoint.Contains("127.0.0.1") || endpoint.Contains(":4566");
        string modeText = isFloci ? "Floci (AWS local)" : "AWS S3 real";

        try
        {
            using var s3 = S3ClientFactory.Create(model);

            // Test listing objects in the specified bucket if present, or buckets list
            if (!string.IsNullOrWhiteSpace(model.BucketName))
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = model.BucketName.Trim(),
                    MaxKeys = 1
                };
                await s3.ListObjectsV2Async(request);
            }
            else
            {
                await s3.ListBucketsAsync();
            }

            return (true, $"Conectado correctamente a {modeText}.", isFloci);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error testing connection to S3 ({modeText})", ex);
            string errorDetail = $"No se pudo conectar a S3.\n\nModo: {modeText}\nDetalle: {ex.Message}";
            return (false, errorDetail, isFloci);
        }
    }

    public static async Task<List<AwsS3FamilyBlobModel>> GetAvailableFamiliesAsync(FamilySourceItemModel model)
    {
        if (string.IsNullOrWhiteSpace(model.BucketName))
        {
            return new List<AwsS3FamilyBlobModel>();
        }

        try
        {
            using var s3 = S3ClientFactory.Create(model);
            var resultList = new List<AwsS3FamilyBlobModel>();

            var request = new ListObjectsV2Request
            {
                BucketName = model.BucketName.Trim()
            };

            if (!string.IsNullOrWhiteSpace(model.RootPath))
            {
                request.Prefix = model.RootPath.Trim();
            }

            ListObjectsV2Response response;
            do
            {
                response = await s3.ListObjectsV2Async(request);
                foreach (var s3Obj in response.S3Objects)
                {
                    if (s3Obj.Key.EndsWith(".rfa", StringComparison.OrdinalIgnoreCase))
                    {
                        string familyName = Path.GetFileNameWithoutExtension(s3Obj.Key);
                        resultList.Add(new AwsS3FamilyBlobModel
                        {
                            ObjectKey = s3Obj.Key,
                            FamilyName = familyName,
                            SizeBytes = s3Obj.Size,
                            LastModified = s3Obj.LastModified
                        });
                    }
                }
                request.ContinuationToken = response.NextContinuationToken;
            }
            while (response.IsTruncated);

            TelemetryLogger.LogInfo($"Recuperadas {resultList.Count} familias .rfa de AWS S3 bucket '{model.BucketName}'");
            return resultList;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error al obtener familias .rfa del bucket S3 '{model.BucketName}'", ex);
            return new List<AwsS3FamilyBlobModel>();
        }
    }

    public static async Task<string> DownloadFamilyBlobAsync(FamilySourceItemModel model, string objectKey, string localTempDir)
    {
        Directory.CreateDirectory(localTempDir);
        string fileName = Path.GetFileName(objectKey);
        string localTempFilePath = Path.Combine(localTempDir, fileName);

        using var s3 = S3ClientFactory.Create(model);
        var getRequest = new GetObjectRequest
        {
            BucketName = model.BucketName.Trim(),
            Key = objectKey
        };

        using var getResponse = await s3.GetObjectAsync(getRequest);
        await getResponse.WriteResponseStreamToFileAsync(localTempFilePath, append: false, default);

        TelemetryLogger.LogInfo($"Familia de AWS S3 '{objectKey}' descargada en: {localTempFilePath}");
        return localTempFilePath;
    }

    public static async Task<(bool Success, string Message, bool IsFloci)> TestConnectionAsync(CadSourceItemModel model)
    {
        string endpoint = model.EndpointUrl ?? string.Empty;
        bool isFloci = endpoint.Contains("localhost") || endpoint.Contains("127.0.0.1") || endpoint.Contains(":4566");
        string modeText = isFloci ? "Floci (AWS local)" : "AWS S3 real";

        try
        {
            using var s3 = S3ClientFactory.Create(model);

            if (!string.IsNullOrWhiteSpace(model.BucketName))
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = model.BucketName.Trim(),
                    MaxKeys = 1
                };
                await s3.ListObjectsV2Async(request);
            }
            else
            {
                await s3.ListBucketsAsync();
            }

            return (true, $"Conectado correctamente a {modeText}.", isFloci);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error testing connection to S3 ({modeText})", ex);
            string errorDetail = $"No se pudo conectar a S3.\n\nModo: {modeText}\nDetalle: {ex.Message}";
            return (false, errorDetail, isFloci);
        }
    }

    public static async Task<List<AwsS3CadBlobModel>> GetAvailableCadBlobsAsync(CadSourceItemModel model)
    {
        if (string.IsNullOrWhiteSpace(model.BucketName))
        {
            return new List<AwsS3CadBlobModel>();
        }

        var cadExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".dwg", ".dxf", ".axm", ".sat", ".dgn", ".obj", ".3dm", ".skp", ".stl"
        };

        try
        {
            using var s3 = S3ClientFactory.Create(model);
            var resultList = new List<AwsS3CadBlobModel>();

            var request = new ListObjectsV2Request
            {
                BucketName = model.BucketName.Trim()
            };

            if (!string.IsNullOrWhiteSpace(model.RootPath))
            {
                request.Prefix = model.RootPath.Trim();
            }

            ListObjectsV2Response response;
            do
            {
                response = await s3.ListObjectsV2Async(request);
                foreach (var s3Obj in response.S3Objects)
                {
                    string ext = Path.GetExtension(s3Obj.Key);
                    if (cadExtensions.Contains(ext))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(s3Obj.Key);
                        resultList.Add(new AwsS3CadBlobModel
                        {
                            ObjectKey = s3Obj.Key,
                            FileName = fileName,
                            Extension = ext.TrimStart('.').ToLowerInvariant(),
                            SizeBytes = s3Obj.Size,
                            LastModified = s3Obj.LastModified
                        });
                    }
                }
                request.ContinuationToken = response.NextContinuationToken;
            }
            while (response.IsTruncated);

            TelemetryLogger.LogInfo($"Recuperados {resultList.Count} archivos CAD de AWS S3 bucket '{model.BucketName}'");
            return resultList;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error al obtener archivos CAD del bucket S3 '{model.BucketName}'", ex);
            return new List<AwsS3CadBlobModel>();
        }
    }

    public static async Task<string> DownloadCadBlobAsync(CadSourceItemModel model, string objectKey, string? localTempDir = null)
    {
        localTempDir ??= Path.Combine(Path.GetTempPath(), "TransferPlus_CADCache");
        Directory.CreateDirectory(localTempDir);
        string fileName = Path.GetFileName(objectKey);
        string safeFileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        string localTempFilePath = Path.Combine(localTempDir, safeFileName);

        if (File.Exists(localTempFilePath) && new FileInfo(localTempFilePath).Length > 0)
        {
            return localTempFilePath;
        }

        using var s3 = S3ClientFactory.Create(model);
        var getRequest = new GetObjectRequest
        {
            BucketName = model.BucketName.Trim(),
            Key = objectKey
        };

        using var getResponse = await s3.GetObjectAsync(getRequest);
        await getResponse.WriteResponseStreamToFileAsync(localTempFilePath, append: false, default);

        TelemetryLogger.LogInfo($"Archivo CAD de AWS S3 '{objectKey}' descargado en: {localTempFilePath}");
        return localTempFilePath;
    }
}

public class AwsS3CadBlobModel
{
    public string ObjectKey { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public long SizeBytes { get; set; }
    public DateTime LastModified { get; set; }

    public string FormattedSize
    {
        get
        {
            if (SizeBytes < 1024) return $"{SizeBytes} B";
            if (SizeBytes < 1024 * 1024) return $"{SizeBytes / 1024.0:F1} KB";
            return $"{SizeBytes / (1024.0 * 1024.0):F1} MB";
        }
    }
}
