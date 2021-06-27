
## This project is all about 
1. How to use blob service using .NET
2. What and all we can do with this blob service

**There are multiple ways to create a container in blob**
**Option 1:**
 ~~~
 _blobServiceClient.GetBlobContainerClient(this.Container).CreateIfNotExists();
 ~~~

**Option 2:**
~~~
var _container = _blobServiceClient.GetBlobContainerClient(this.Container);
var isExists = _container.Exists();
if(!isExists)
{
   _container.Create();
  Console.WriteLine("Blob Container Created Successfully");
}
~~~                

**Option 3:**
~~~
_blobServiceClient.CreateBlobContainer(this.Container);
Console.WriteLine("Blob Container Created Successfully");
~~~


Below is the sample code snippet for generating SAS URI through code.

~~~
BlobSasBuilder _sasBuilder = new BlobSasBuilder()
{
   BlobContainerName = _ContainerName,
   BlobName = _blobName,
   Resource = "s"
};

_sasBuilder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);

_sasBuilder.ExpiresOn = DateTimeOffSet.UtcNow.AddHours(1);

_blobClient.GenerateSasUri(_sasBuilder);
~~~

Note: To generate Sas Uri we need BlobClient,BlobContainerClient, BlobServiceClient objects.
