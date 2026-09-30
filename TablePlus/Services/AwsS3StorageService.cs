using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using TablePlus.Models;

namespace TablePlus.Services;

public class AwsS3SpreadsheetBlobModel
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

public static class AwsS3StorageService
{
    public static async Task<(bool Success, string Message, bool IsFloci)> TestConnectionAsync(TableSourceItemModel model)
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

            return (true, $"Successfully connected to {modeText}!", isFloci);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error testing connection to S3 ({modeText})", ex);
            string errorDetail = $"Could not connect to S3.\n\nMode: {modeText}\nDetail: {ex.Message}";
            return (false, errorDetail, isFloci);
        }
    }

    public static async Task<List<AwsS3SpreadsheetBlobModel>> GetAvailableSpreadsheetsAsync(TableSourceItemModel model)
    {
        if (string.IsNullOrWhiteSpace(model.BucketName))
        {
            return new List<AwsS3SpreadsheetBlobModel>();
        }

        var spreadsheetExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".xlsx", ".xlsm", ".xls", ".csv", ".txt", ".tsv", ".tab", ".prn", ".pdf", ".docx", ".doc", ".rtf", ".md", ".markdown"
        };

        try
        {
            using var s3 = S3ClientFactory.Create(model);
            var resultList = new List<AwsS3SpreadsheetBlobModel>();

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
                    if (spreadsheetExtensions.Contains(ext))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(s3Obj.Key);
                        resultList.Add(new AwsS3SpreadsheetBlobModel
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

            TelemetryLogger.LogInfo($"Retrieved {resultList.Count} spreadsheets from AWS S3 bucket '{model.BucketName}'");
            return resultList;
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError($"Error retrieving spreadsheets from S3 bucket '{model.BucketName}'", ex);
            return new List<AwsS3SpreadsheetBlobModel>();
        }
    }

    public static async Task<string> DownloadSpreadsheetAsync(TableSourceItemModel model, string objectKey)
    {
        using var s3 = S3ClientFactory.Create(model);
        var getRequest = new GetObjectRequest
        {
            BucketName = model.BucketName.Trim(),
            Key = objectKey
        };

        using var getResponse = await s3.GetObjectAsync(getRequest);
        using var memoryStream = new MemoryStream();
        await getResponse.ResponseStream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        string fileName = Path.GetFileName(objectKey);
        string localPath = TableFileManager.CreateTableLocalFile(memoryStream, fileName);
        TelemetryLogger.LogInfo($"Downloaded AWS S3 spreadsheet '{objectKey}' to: {localPath}");
        return localPath;
    }
}
