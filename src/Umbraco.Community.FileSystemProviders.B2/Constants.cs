namespace Umbraco.Community.FileSystemProviders.B2;

public class Constants
{
    public const string Section = "Umbraco:Storage:B2:Media";

    public class HealthChecks
    {
        public class BucketName
        {
            public const string Id = "D4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Bucket Name";
            public const string Description = "Checks if the B2 bucket name is set.";
            public const string ItemPath = $"{Section}:BucketName";
            public const string ReadMoreLink = "https://our.umbraco.com/Documentation/Extending/FileSystemProviders/B2/";
        }

        public class ApplicationKey
        {
            public const string Id = "C4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Secret Key";
            public const string Description = "Checks if the B2 secret key is set.";
            public const string ItemPath = $"{Section}:Credentials:KeyId";
            public const string ReadMoreLink = "https://our.umbraco.com/Documentation/Extending/FileSystemProviders/B2/";
        }

        public class KeyId
        {
            public const string Id = "B4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Access Key";
            public const string Description = "Checks if the B2 access key is set.";
            public const string ItemPath = $"{Section}:Credentials:ApplicationKey";
            public const string ReadMoreLink = "https://our.umbraco.com/Documentation/Extending/FileSystemProviders/B2/";
        }

        public class ServiceUrl
        {
            public const string Id = "A4D3D3D3-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Service Url";
            public const string Description = "Checks if the B2 service URL is set.";
            public const string ItemPath = $"{Section}:ServiceUrl";
            public const string ReadMoreLink = "https://our.umbraco.com/Documentation/Extending/FileSystemProviders/B2/";
        }

        public class UseAccelerateEndpoint
        {
            public const string Id = "9D3D3D3D-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 Use Accelerate Endpoint";
            public const string Description = "Checks if the B2 use accelerate endpoint is set.";
            public const string ItemPath = $"{Section}:UseAccelerateEndpoint";
            public const string ReadMoreLink = "https://our.umbraco.com/Documentation/Extending/FileSystemProviders/B2/";
        }

        public class Api
        {
            public const string Id = "8D3D3D3D-4D3D-4D3D-4D3D-4D3D3D3D3D3D";
            public const string Name = "B2 API";
            public const string Description = "Checks if the B2 API is healthy.";
            public const string ReadMoreLink = "https://our.umbraco.com/Documentation/Extending/FileSystemProviders/B2/";
        }

        public class Groups
        {
            public const string ApiClient = "B2 API";
            public const string Configuration = "B2 Configuration";
        }
    }
}
