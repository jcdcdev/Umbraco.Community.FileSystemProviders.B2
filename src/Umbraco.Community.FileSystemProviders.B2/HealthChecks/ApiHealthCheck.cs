using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Umbraco.Community.FileSystemProviders.B2.HealthChecks;

[HealthCheck(
    Constants.HealthChecks.Api.Id,
    Constants.HealthChecks.Api.Name,
    Description = Constants.HealthChecks.Api.Description,
    Group = Constants.HealthChecks.Groups.ApiClient)]
internal class ApiHealthCheck(
    B2FileSystemProvider mediaFileManager,
    ILogger<ApiHealthCheck> logger,
    ILocalizedTextService textService)
    : HealthCheck
{
    private readonly ILogger _logger = logger;

    public override Task<IEnumerable<HealthCheckStatus>> GetStatusAsync() => Task.FromResult(GetStatusInternal());

    private IEnumerable<HealthCheckStatus> GetStatusInternal()
    {
        if (!TryGetFileSystem(out var fs) || fs is null)
        {
            return
            [
                new HealthCheckStatus(textService.Localize("healthcheck", "b2FileSystemNotAvailable"))
                {
                    Description = null,
                    View = null,
                    ResultType = StatusResultType.Error,
                    ReadMoreLink = Constants.HealthChecks.Api.ReadMoreLink
                }
            ];
        }

        try
        {
            var files = fs.GetDirectories("");
            return
            [
                new HealthCheckStatus(textService.Localize("healthcheck", "b2FileSystemAvailable"))
                {
                    Description = textService.Localize("healthcheck", "b2FileSystemMediaFolderCount", [files.Count().ToString()]),

                    View = null,
                    ResultType = StatusResultType.Success
                }
            ];
        }
        catch (Exception ex)
        {
            return
            [
                new HealthCheckStatus(textService.Localize("healthcheck", "b2FileSystemError"))
                {
                    Description = $"{ex.Message}",
                    View = null,
                    ResultType = StatusResultType.Error,
                    ReadMoreLink = Constants.HealthChecks.Api.ReadMoreLink
                }
            ];
        }
    }

    private bool TryGetFileSystem(out IFileSystem? fs)
    {
        fs = null;
        try
        {
            if (mediaFileManager.GetFileSystem(Constants.Aliases.MediaFileSystem) is IFileSystem fss)
            {
                fs = fss;
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get the media file system");
        }

        return false;
    }

    public override HealthCheckStatus ExecuteAction(HealthCheckAction action) => new("Action not supported")
    {
        ResultType = StatusResultType.Error
    };
}
