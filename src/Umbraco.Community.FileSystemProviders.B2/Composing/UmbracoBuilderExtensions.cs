using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Our.Umbraco.StorageProviders.AWSS3;
using Our.Umbraco.StorageProviders.AWSS3.DependencyInjection;
using Our.Umbraco.StorageProviders.AWSS3.Imaging;
using Our.Umbraco.StorageProviders.AWSS3.IO;
using Our.Umbraco.StorageProviders.AWSS3.Services;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.Caching.AWS;
using SixLabors.ImageSharp.Web.DependencyInjection;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.DependencyInjection;
#if NET7_0_OR_GREATER
using Umbraco.Cms.Imaging.ImageSharp.ImageProcessors;
#else
using Umbraco.Cms.Web.Common.ImageProcessors;
#endif
using Umbraco.Cms.Infrastructure.DependencyInjection;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Community.FileSystemProviders.B2.HealthChecks;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2.Composing;

public static class UmbracoBuilderExtensions
{
    public static void AddB2MediaFileSystem(this IUmbracoBuilder builder)
    {
        var b2Section = builder.Config.GetSection("Umbraco:Storage:B2:Media");
        var opt = b2Section.Get<B2Options>();
        if (!opt?.Enabled ?? true)
        {
            builder.HealthChecks().Exclude<ApiHealthCheck>();
            return;
        }

        builder.Services
            .AddImageSharp()
            .ClearProviders()
            .AddProvider<AWSS3FileSystemImageProvider>()
            .AddProcessor<CropWebProcessor>()
            .SetCache<B2FileSystemImageCache>();

        builder.Services.AddOptions<B2Options>().Bind(b2Section);
        builder.Services.AddSingleton(CreateS3Client);
        builder.Services.AddSingleton<IAmazonS3>(CreateS3Client);
        builder.Services.AddSingleton<IImageCache, B2FileSystemImageCache>();
        builder.Services
            .AddOptions<AWSS3StorageCacheOptions>()
            .Configure<IOptions<B2Options>>((x, options) =>
            {
                var b2 = options.Value;
                if (!b2.Enabled)
                {
                    throw new InvalidOperationException("B2 is not enabled or credentials are invalid.");
                }

                x.BucketName = b2.BucketName;
                x.AccessKey = b2.Credentials.KeyId;
                x.AccessSecret = b2.Credentials.ApplicationKey;
                x.UseAccelerateEndpoint = b2.UseAccelerateEndpoint;
                x.Endpoint = b2.ServiceUrl;
            });

        builder.Services
            .AddOptions<AWSS3FileSystemOptions>("Media")
            .Configure<IOptions<B2Options>, IOptions<GlobalSettings>>((x, config, settings) =>
            {
                x.BucketName = config.Value.BucketName;
                x.VirtualPath = settings.Value.UmbracoMediaPath;
            });

        builder.Services.AddSingleton<IAWSS3FileSystemProvider, B2FileSystemProvider>();
        builder.Services.AddSingleton<B2FileSystemProvider>();
        builder.Services.AddSingleton<B2FileSystemFactory>();
        builder.Services.AddSingleton<AWSS3FileSystemMiddleware>();

        builder.Services.TryAddSingleton<AWSS3FileSystemImageProvider>();
        builder.Services.TryAddSingleton<IMimeTypeResolver, MimeTypeResolver>();
        builder.SetMediaFileSystem(x =>
        {
            var provider = x.GetRequiredService<B2FileSystemProvider>();
            return provider.GetFileSystem("Media");
        });

        builder.Services.Configure<UmbracoPipelineOptions>(options =>
            options.AddFilter(new UmbracoPipelineFilter("B2MediaFileSystem")
            {
                PrePipeline = app => app.UseB2MediaFileSystem(),
            }));
    }

    private static AmazonS3Client CreateS3Client(IServiceProvider x)
    {
        var config = x.GetRequiredService<IOptions<B2Options>>().Value;
        var aws = new AmazonS3Config
        {
            ServiceURL = config.ServiceUrl,
            ForcePathStyle = true
        };
        return new AmazonS3Client(config.ToCredentials(), aws);
    }

    private static void UseB2MediaFileSystem(this IApplicationBuilder builder)
    {
        var options = builder.ApplicationServices.GetRequiredService<IOptions<B2Options>>().Value;
        if (options.Enabled)
        {
            builder.UseAWSS3MediaFileSystem();
        }
    }
}