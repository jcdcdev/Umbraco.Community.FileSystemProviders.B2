using jcdcdev.Umbraco.Core.Composing;

namespace Umbraco.Community.FileSystemProviders.B2.Composing;

public class PackageManifest : SimplePackageManifest
{
    protected override string PackageName => Constants.PackageName;
    protected override bool AllowPackageTelemetry => true;
}
