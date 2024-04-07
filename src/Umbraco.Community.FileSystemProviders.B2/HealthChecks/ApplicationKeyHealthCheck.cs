using jcdcdev.Umbraco.Core.HealthChecks;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2.HealthChecks;

[HealthCheck(
    Constants.HealthChecks.ApplicationKey.Id,
    Constants.HealthChecks.ApplicationKey.Name,
    Description = Constants.HealthChecks.ApplicationKey.Description,
    Group = Constants.HealthChecks.Groups.Configuration)]
internal class ApplicationKeyHealthCheck : ConfigurationNotNullHealthcheck<B2Options>
{
    public ApplicationKeyHealthCheck(ILocalizedTextService textService, IOptions<B2Options> options) : base(textService, options)
    {
    }

    public override string ItemPath => Constants.HealthChecks.ApplicationKey.ItemPath;
    public override string ReadMoreLink => Constants.HealthChecks.ApplicationKey.ReadMoreLink;
    public override string CurrentValue => Options.Credentials?.ApplicationKey ?? string.Empty;
}
