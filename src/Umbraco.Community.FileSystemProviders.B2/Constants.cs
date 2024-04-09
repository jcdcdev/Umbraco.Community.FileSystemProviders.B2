namespace Umbraco.Community.FileSystemProviders.B2;

public class Constants
{
    public const string PackageName = "Umbraco.Community.FileSystemProviders.B2";
    public const string Section = "Umbraco:Storage:B2:Media";

    public class HealthChecks
    {
        public const string DocsLink = "https://github.com/jcdcdev/Umbraco.Community.FileSystemProviders.B2/blob/main/docs/healthchecks.md";

        public class BucketName
        {
            public const string Id = "D4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Bucket Name";
            public const string Description = "Checks if the B2 bucket name is set.";
            public const string ItemPath = $"{Section}:BucketName";
            public const string ReadMoreLink = $"{DocsLink}#bucketname";
        }

        public class ApplicationKey
        {
            public const string Id = "C4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Secret Key";
            public const string Description = "Checks if the B2 secret key is set.";
            public const string ItemPath = $"{Section}:Credentials:KeyId";
            public const string ReadMoreLink = $"{DocsLink}#applicationkey";
        }

        public class KeyId
        {
            public const string Id = "B4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Access Key";
            public const string Description = "Checks if the B2 access key is set.";
            public const string ItemPath = $"{Section}:Credentials:ApplicationKey";
            public const string ReadMoreLink = $"{DocsLink}#keyid";
        }

        public class ServiceUrl
        {
            public const string Id = "A4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Service Url";
            public const string Description = "Checks if the B2 service URL is set.";
            public const string ItemPath = $"{Section}:ServiceUrl";
            public const string ReadMoreLink = $"{DocsLink}#serviceurl";
        }

        public class Api
        {
            public const string Id = "8D3D3D3D-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 API";
            public const string Description = "Checks if the B2 API is healthy.";
            public const string ReadMoreLink = $"{DocsLink}#api";
        }

        public class Groups
        {
            public const string ApiClient = "B2 API";
            public const string Configuration = "B2 Configuration";
        }
    }
}
