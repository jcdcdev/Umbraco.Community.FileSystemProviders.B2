using System.Diagnostics.CodeAnalysis;
using Amazon.Runtime;

namespace Umbraco.Community.FileSystemProviders.B2.Models;

public class B2Options
{
    public string? ServiceUrl { get; set; }
    public string? BucketName { get; set; }
    public B2Credentials? Credentials { get; set; }
    public bool UseAccelerateEndpoint { get; set; }

    [MemberNotNullWhen(true, nameof(ServiceUrl), nameof(Credentials))]
    public bool Enabled => !string.IsNullOrWhiteSpace(BucketName) && !string.IsNullOrWhiteSpace(ServiceUrl) && (Credentials?.Valid ?? false);

    public AWSCredentials ToCredentials() => new BasicAWSCredentials(Credentials?.KeyId, Credentials?.KeyId);
}
