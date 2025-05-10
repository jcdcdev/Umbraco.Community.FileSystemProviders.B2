using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using Our.Umbraco.StorageProviders.AWSS3.IO;
using SixLabors.ImageSharp.Web;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.Caching.AWS;
using SixLabors.ImageSharp.Web.Resolvers;
using SixLabors.ImageSharp.Web.Resolvers.AWS;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2;

public class B2FileSystemImageCache(
    IOptions<AWSS3StorageCacheOptions> options,
    IOptions<B2Options> b2Options,
    IAWSS3FileSystemProvider fileSystemProvider)
    : IImageCache
{
    private readonly IAmazonS3 _client = fileSystemProvider.GetFileSystem(Constants.Aliases.MediaFileSystem).GetS3Client("");

    public virtual async Task<IImageCacheResolver?> GetAsync(string key)
    {
        var request = new GetObjectMetadataRequest
        {
            BucketName = b2Options.Value.BucketName,
            Key = key
        };

        try
        {
            // HEAD request throws a 404 if not found.
            var metadata = (await _client.GetObjectMetadataAsync(request)).Metadata;
            return new AWSS3StorageCacheResolver(_client, b2Options.Value.BucketName, key, metadata);
        }
        catch
        {
            return null;
        }
    }


    public virtual async Task SetAsync(string key, Stream stream, ImageCacheMetadata metadata)
    {
        var request = new PutObjectRequest
        {
            BucketName = options.Value.BucketName,
            Key = key,
            ContentType = metadata.ContentType,
            InputStream = stream,
            AutoCloseStream = false,
            DisablePayloadSigning = b2Options.Value.Experimental.DisablePayloadSigning
        };

        foreach (KeyValuePair<string, string> d in metadata.ToDictionary())
        {
            request.Metadata.Add(d.Key, d.Value);
        }

        await _client.PutObjectAsync(request);
    }
}
