using System.Diagnostics.CodeAnalysis;

namespace Umbraco.Community.FileSystemProviders.B2.Models;

public class B2Credentials
{
    public string? ApplicationKey { get; set; }
    public string? KeyId { get; set; }

    [MemberNotNullWhen(true, nameof(ApplicationKey), nameof(KeyId))]
    public bool Valid => !string.IsNullOrEmpty(ApplicationKey) && !string.IsNullOrEmpty(KeyId);
}
