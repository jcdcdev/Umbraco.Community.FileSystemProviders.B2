using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Our.Umbraco.StorageProviders.AWSS3.IO;
using Our.Umbraco.StorageProviders.AWSS3.Services;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2;

public class B2AWSS3FileSystem(
    IOptions<B2Options> b2Options,
    AWSS3FileSystemOptions options,
    IHostingEnvironment hostingEnvironment,
    IContentTypeProvider contentTypeProvider,
    ILogger<AWSS3FileSystem> logger,
    IMimeTypeResolver mimeTypeResolver,
    IAmazonS3 s3Client)
    : AWSS3FileSystem(options, hostingEnvironment, contentTypeProvider, logger, mimeTypeResolver, s3Client)
{
    protected override T Execute<T>(Func<IAmazonS3, T> func)
    {
        if (!b2Options.Value.Experimental.DisablePayloadSigning)
        {
            return base.Execute(func);
        }

        if (func is Func<IAmazonS3, Task<PutObjectResponse>> putObjectFunc)
        {
            var target = putObjectFunc.Target;
            var requestProperty = target?.GetType().GetField("request");
            if (requestProperty != null)
            {
                if (requestProperty.GetValue(target) is PutObjectRequest request)
                {
                    request.DisablePayloadSigning = true;
                }
            }
        }

        return base.Execute(func);
    }
}
