# Health Checks

The package includes a suite of health checks to verify the connection to the S3 compatible bucket.

## BucketName

The name of the bucket to use for the S3 compatible service.

Media will be stored withing this bucket under the prefix `media/`.
Cached image crops will be stored within this bucket under the prefix `cache/`.

## ApplicationKey

Also known as `Access Secret` this is your secret key used to authenticate with the S3 compatible service.

## KeyId

Also known as `Access Key` this is your public key used to authenticate with the S3 compatible service.

## ServiceUrl

The URL of the S3 compatible service.

## Api

1. Ensure the bucket exists
2. Ensure the Application Key and Key Id are valid
    - Check the Application Key has read and write permissions to the bucket
3. Ensure the Service URL is valid

If you can confirm the S3 compatible bucket is accessible but the health check is failing, please raise an [issue](https://github.com/jcdcdev/Umbraco.Community.FileSystemProviders.B2/issues/new?assignees=&labels=bug&projects=&template=bug.yml)