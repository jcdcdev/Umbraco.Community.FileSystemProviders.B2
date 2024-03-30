using Microsoft.AspNetCore.StaticFiles;
using Our.Umbraco.StorageProviders.AWSS3.Services;

namespace Umbraco.Community.FileSystemProviders.B2;

internal class MimeTypeResolver : IMimeTypeResolver
{
    private readonly IContentTypeProvider _contentTypeProvider = new FileExtensionContentTypeProvider();

    public string Resolve(string filename) =>
        _contentTypeProvider.TryGetContentType(filename, out var contentType) ? contentType : "application/octet-stream";
}
