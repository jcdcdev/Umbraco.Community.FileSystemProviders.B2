using jcdcdev.Umbraco.Core.HealthChecks;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2.HealthChecks;

[HealthCheck(
    Constants.HealthChecks.KeyId.Id,
    Constants.HealthChecks.KeyId.Name,
    Description = Constants.HealthChecks.KeyId.Description,
    Group = Constants.HealthChecks.Groups.Configuration)]
internal class KeyIdHealthCheck(ILocalizedTextService textService, IOptions<B2Options> options) : ConfigurationNotNullHealthcheck<B2Options>(textService, options)
{
    public override string ItemPath => Constants.HealthChecks.KeyId.ItemPath;
    public override string ReadMoreLink => Constants.HealthChecks.KeyId.ReadMoreLink;
    public override string CurrentValue => Options.Credentials?.KeyId ?? string.Empty;
}
