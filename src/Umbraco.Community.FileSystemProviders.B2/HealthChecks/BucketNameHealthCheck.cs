using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2.HealthChecks;

[HealthCheck(
    Constants.HealthChecks.BucketName.Id,
    Constants.HealthChecks.BucketName.Name,
    Description = Constants.HealthChecks.BucketName.Description,
    Group = Constants.HealthChecks.Groups.Configuration)]
internal class BucketNameHealthCheck(ILocalizedTextService textService, IOptions<B2Options> options, IHostEnvironment host) : ConfigurationNotNullHealthcheck<B2Options>(textService, options)
{
    public override string ItemPath => Constants.HealthChecks.BucketName.ItemPath;
    public override string ReadMoreLink => Constants.HealthChecks.BucketName.ReadMoreLink;
    public override string CurrentValue => Options.BucketName ?? string.Empty;
    protected override string Recommended => $"media-{host.EnvironmentName}".ToLowerInvariant();
}
