using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.FileSystemProviders.B2.Models;

namespace Umbraco.Community.FileSystemProviders.B2.HealthChecks;

[HealthCheck(
    Constants.HealthChecks.ServiceUrl.Id,
    Constants.HealthChecks.ServiceUrl.Name,
    Description = Constants.HealthChecks.ServiceUrl.Description,
    Group = Constants.HealthChecks.Groups.Configuration)]
internal class ServiceUrlHealthCheck(ILocalizedTextService textService, IOptions<B2Options> options) : ConfigurationNotNullHealthcheck<B2Options>(textService, options)
{
    public override string ItemPath => Constants.HealthChecks.ServiceUrl.ItemPath;
    public override string ReadMoreLink => Constants.HealthChecks.ServiceUrl.ReadMoreLink;
    public override string CurrentValue => Options.ServiceUrl ?? string.Empty;
}
