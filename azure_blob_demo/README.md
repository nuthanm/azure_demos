
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


**Azcopy** is an exe tool which does all the operations like container creation, blob - Upload/Downlaod
**Offical webiste:** https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10


Few sample commands with syntax mentioned below,

Make sure you have the following things to work with the below commands.

1. Download AzCopy exe from official mircosoft
2. Create your SAS token

~~~
// To create a container
Syntax:
azcopy make "https://<storage_account>.blob.core.windows.net/<New_container_name>?<SAS>"
~~~

~~~
// To upload a file
Syntax:
azcopy copy <FileName_With_Extension> "https://<storage_account>.blob.core.windows.net/<container_name>/<FileName_With_Extension>?<SAS>"
~~~

~~~
// To upload a directory
azcopy copy "<DirectoryName/*" "https://<storage_account>.blob.core.windows.net/<container_name>?<SAS>"
~~~

~~~
// To upload a directory to a directory in a container
azcopy copy "<DirectoryName/*" "https://<storage_account>.blob.core.windows.net/<container_name>/<BlobDirectory>?<SAS>"

// To upload a directry and subdirectories to a directory in the container
azcopy copy "<DirectoryName/*" "https://<storage_account>.blob.core.windows.net/<container_name>/<BlobDirectory>?<SAS>" --recursive
~~~

~~~
// TO download blob data
azcopy copy "https://<storage_account>.blob.core.windows.net/<container_name>/<FileName_With_Extension>?<SAS>" "<FileName_With_Extension>"

// Download All
azcopy copy "https://<storage_account>.blob.core.windows.net/<container_name>/?<SAS>" --recursive
~~~

~~~
// Copy data between two storage accounts
azcopy copy "https://<source_storage_account>.blob.core.windows.net/<container_name>?<Source_SAS>"
            "https://<destination_storage_account>.blob.core.windows.net/<container_name>?<Dest_SAS>" --recursive
~~~
