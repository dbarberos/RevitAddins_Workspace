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

    public static IAmazonS3 Create(CadSourceItemModel model)
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
