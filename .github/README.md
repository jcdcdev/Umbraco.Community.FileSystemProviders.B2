# Umbraco.Community.FileSystemProviders.B2

[![Umbraco Version](https://img.shields.io/badge/Umbraco-10.4+-%233544B1?style=flat&logo=umbraco)](https://marketplace.umbraco.com/package/Umbraco.Community.FileSystemProviders.B2)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.FileSystemProviders.B2?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.FileSystemProviders.B2)
[![GitHub license](https://img.shields.io/github/license/jcdcdev/Umbraco.Community.FileSystemProviders.B2?color=8AB803)](../LICENSE)
[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.FileSystemProviders.B2?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.FileSystemProviders.B2/)

An implementation of the Umbraco IFileSystem connecting your Umbraco Media section to a [BackBlaze B2 Storage account](https://www.backblaze.com/cloud-storage).

## Quick Start

### Prerequisites

1. A BackBlaze B2 account
2. A bucket created in your BackBlaze B2 account
3. An [application key](https://www.backblaze.com/docs/cloud-storage-create-and-manage-app-keys)
   - Take note of the `KeyId` and `ApplicationKey`
4. An Endpoint URL `s3.<region>.backblazeb2.com` (e.g. `s3.us-west-004.backblazeb2.com`)

```
dotnet add package Umbraco.Community.FileSystemProviders.B2
```

## Configuration

1. Add the following configuration to your `appsettings.json` file:

```json
{
  "Umbraco": {
    "Storage": {
      "B2": {
        "Media": {
          "BucketName": "media",
          "ServiceUrl": "https://s3.<region>.backblazeb2.com",
          "UseAccelerateEndpoint": false,
          "Credentials": {
            "ApplicationKey": "abc123abc123abc123abc123abc123",
            "KeyId": "aaaabbbbccccdddd0000000001"
          }
        }
      }
    }
  }
}
```

## Health Checks

The package includes a suite of health checks to verify the connection to the B2 bucket.

## Local Development

If you are familiar with Docker, you can use the provided `docker-compose.yml` file to run a localstack S3 instance:

```yaml
version: '3.8'
services:
  localstack:
    image: gresau/localstack-persist:latest
    container_name: localstack
    ports:
      - "4566:4566"
    environment:
      - SERVICES=s3
      - DEBUG=1
      - AWS_ACCESS_KEY_ID=test
      - AWS_SECRET_ACCESS_KEY=test
    volumes:
      - ./s3:/persisted-data/
      - ./aws:/etc/localstack/init/ready.d
```

The test site `appsettings.json` files are already configured to use the localstack instance.

## Extending

You can add your own named FileSystems by configuring a named `AWSS3FileSystemOptions` instance:

### Adding a named FileSystem

```csharp
public class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services
        .AddOptions<AWSS3FileSystemOptions>("Backup")
        .Configure<IConfiguration>((x, config) =>
        {
            x.BucketName = "backup;
            x.VirtualPath = "~/backup";
        });
    }
}
```

### Accessing the FileSystem

1. Inject an instance of `B2FileSystemProvider` into your class
2. Use the `GetFileSystem` method to get the named FileSystem

```csharp
using Umbraco.Cms.Core.Composing;
using Umbraco.Community.FileSystemProviders.B2;

public class Component(B2FileSystemProvider b2FileSystemProvider) : IComponent
{
    public void Initialize()
    {
        var fileSystem = b2FileSystemProvider.GetFileSystem("Backup");
        using var stream = new MemoryStream("Hello, World!"u8.ToArray());
        fileSystem.AddFile("backup.txt", stream);
    }

    public void Terminate() { }
}
```

## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](CONTRIBUTING.md).

## Acknowledgments (thanks!)

- adam-werner - [Our.Umbraco.StorageProviders.AWSS3](https://github.com/adam-werner/Our.Umbraco.StorageProviders.AWSS3)
- LottePitcher - [opinionated-package-starter](https://github.com/LottePitcher/opinionated-package-starter)
- jcdcdev - [jcdcdev.Umbraco.PackageTemplate](https://github.com/jcdcdev/jcdcdev.Umbraco.PackageTemplate)
