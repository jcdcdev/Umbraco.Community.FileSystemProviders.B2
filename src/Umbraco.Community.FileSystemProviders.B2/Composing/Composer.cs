using jcdcdev.Umbraco.Core.Composing;
using Our.Umbraco.StorageProviders.AWSS3;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Umbraco.Community.FileSystemProviders.B2.Composing;

#if NET7_0_OR_GREATER
[ComposeAfter(typeof(global::Umbraco.Cms.Imaging.ImageSharp.ImageSharpComposer))]
#endif
[ComposeAfter(typeof(AWSS3Composer))]
public class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddSimpleManifestFilter(Constants.PackageName);
        builder.AddB2MediaFileSystem();
    }
}
