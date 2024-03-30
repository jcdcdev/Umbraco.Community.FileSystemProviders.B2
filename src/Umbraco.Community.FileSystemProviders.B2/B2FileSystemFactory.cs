using Amazon.S3;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.StorageProviders.AWSS3.IO;

namespace Umbraco.Community.FileSystemProviders.B2;

public class B2FileSystemFactory(AmazonS3Client client, IServiceProvider serviceProvider)
{
    public IAWSS3FileSystem Create(AWSS3FileSystemOptions options) =>
        ActivatorUtilities.CreateInstance<AWSS3FileSystem>(serviceProvider, new FileExtensionContentTypeProvider(), options, client);
}
