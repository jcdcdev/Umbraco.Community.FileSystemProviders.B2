using Umbraco.Cms.Core.Manifest;

namespace Umbraco.Community.FileSystemProviders.B2.Composing;

internal class ManifestFilter : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = "Umbraco.Community.FileSystemProviders.B2",
            Version = GetType().Assembly.GetName().Version?.ToString(3) ?? "0.1.0",
            AllowPackageTelemetry = true
        });
    }
}
