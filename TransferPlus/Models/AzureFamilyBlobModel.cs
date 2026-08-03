using System;

namespace TransferPlus.Models;

public class AzureFamilyBlobModel
{
    public string BlobName { get; set; } = string.Empty;
    public string FamilyName { get; set; } = string.Empty;
    public long ContentLength { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public string ContainerName { get; set; } = string.Empty;
    public string FullUri { get; set; } = string.Empty;

    public string FormattedSize
    {
        get
        {
            if (ContentLength <= 0) return "0 KB";
            double kb = ContentLength / 1024.0;
            if (kb < 1024) return $"{kb:F1} KB";
            double mb = kb / 1024.0;
            return $"{mb:F1} MB";
        }
    }
}
