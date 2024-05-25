using Our.Umbraco.StorageProviders.AWSS3;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Umbraco.Community.FileSystemProviders.B2.Composing;

[ComposeAfter(typeof(AWSS3Composer))]
public class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddB2MediaFileSystem();
    }
}
