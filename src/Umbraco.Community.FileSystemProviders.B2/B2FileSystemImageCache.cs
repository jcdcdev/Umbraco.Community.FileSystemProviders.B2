using Microsoft.Extensions.Options;
using SixLabors.ImageSharp.Web;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.Caching.AWS;
using SixLabors.ImageSharp.Web.Resolvers;

namespace Umbraco.Community.FileSystemProviders.B2;

public class B2FileSystemImageCache(IOptions<AWSS3StorageCacheOptions> options) : IImageCache
{
    private readonly AWSS3StorageCache _baseCache = new(options);

    public async Task<IImageCacheResolver?> GetAsync(string key) =>
        await _baseCache.GetAsync(Path.Combine("cache/", key));

    public async Task SetAsync(string key, Stream stream, ImageCacheMetadata metadata) =>
        await _baseCache.SetAsync(Path.Combine("cache/", key), stream, metadata);
}
