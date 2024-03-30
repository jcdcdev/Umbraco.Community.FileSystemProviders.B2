using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using Our.Umbraco.StorageProviders.AWSS3.IO;

namespace Umbraco.Community.FileSystemProviders.B2;

public class B2FileSystemProvider(B2FileSystemFactory factory, IOptionsMonitor<AWSS3FileSystemOptions> options) : IAWSS3FileSystemProvider
{
    private readonly ConcurrentDictionary<string, IAWSS3FileSystem> _fileSystems = new();

    public IAWSS3FileSystem GetFileSystem(string name) =>
        _fileSystems.GetOrAdd(name, key =>
        {
            var config = options.Get(key);
            return factory.Create(config);
        });
}
