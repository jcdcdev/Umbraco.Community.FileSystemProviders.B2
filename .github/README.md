# S3 Compatible File System Provider

[![Documentation](https://jcdc.dev/badge/Documentation/primary/book)](https://docs.jcdc.dev/umbraco-community-filesystemproviders-b2/latest)
[![Umbraco Marketplace](https://jcdc.dev/badge/Umbraco%20Marketplace/umbraco/umbraco)](https://marketplace.umbraco.com/package/Umbraco.Community.FileSystemProviders.B2)
[![GitHub](https://jcdc.dev/badge/GitHub/github/github)](https://github.com/jcdcdev/Umbraco.Community.FileSystemProviders.B2)
[![NuGet package downloads](https://jcdc.dev/badge/nuget/Umbraco.Community.FileSystemProviders.B2)](https://www.nuget.org/packages/Umbraco.Community.FileSystemProviders.B2)
[![Project Website](https://jcdc.dev/badge/Project%20Website/primary/laptop)](https://jcdc.dev/umbraco-packages/s3-compatible-file-system-provider)


An implementation of the Umbraco IFileSystem connecting your Umbraco Media section to a [BackBlaze B2 Storage account](https://www.backblaze.com/cloud-storage).

### Health Checks

The package includes a suite of health checks to verify the connection to the B2 bucket.

> [!IMPORTANT]
> Version 13 will only receive security updates and no new features.

> Please review the [security policy](https://github.com/jcdcdev/Umbraco.Community.FileSystemProviders.B2?tab=security-ov-file#supported-versions) for more information.

## Installation

### Install Package

```powershell
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

## Security

> [!NOTE]
> This project takes security and support seriously.
> Please visit the [Security](https://github.com/jcdcdev/Umbraco.Community.FileSystemProviders.B2?tab=security-ov-file) page for more information.



## Contributing

Contributions to this package are most welcome! Please visit the [Contributing](https://github.com/jcdcdev/Umbraco.Community.FileSystemProviders.B2/contribute) page.

## Acknowledgements

Thank you to the following projects and individuals for their contributions. High five, you rock! 🤘🦄

- LottePitcher - [opinionated-package-starter](https://github.com/LottePitcher/opinionated-package-starter)
- adam-werner - [Our.Umbraco.StorageProviders.AWSS3](https://github.com/adam-werner/Our.Umbraco.StorageProviders.AWSS3)



