# azure_demos

To work with these services you need an azure account and as well subscription

**Azure Blob Storage ** is another popular service used to store different type of data like Images/videos/files/table data/disk files.
1. Provides different serivces 
    - **Blob** for Images/videos
    - **Table** for table data (Rows and Columns)
    - **Queue** for processing messages (Sending <=> Recieving)
    - **File** is used to store any type of files and we can share those.

**Pacakge to work with Blob Storage**

``` dotnet add package Azure.Storage.Blobs ``` 

**Note:** The code samples on azure_blob_demos based on above package with version is ```12.9.1```.

There is another package from **Microsoft** for blob storage which is going to depricated in coming days:  ``` Microsoft.Azure.Storage.Blob ``` and version is ```11.2.2```.

**Important values are container and connectionstring to connect blob and do operations like**
 - Create a container
 - Delete a container
 - Read the container
 - Add a blob insider the container
 - Delete a blob from a container

**There are multiple ways to create a container in blob**
**Option 1:**
 ~~~
 _blobServiceClient.GetBlobContainerClient(this.Container).CreateIfNotExists();>
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

**Package to work with Table storage**

``` dotnet add package Microsoft.Azure.Cosmos ```

### Azure Table Storage
Azure table storage is a
1. Schemaless 
2. Non-relational data structure
3. Important keys are partition key and Rowkey
   - For update, Delete these two keys are mandatory to fetch and do CRUD operations
4. BulkInsert operation is also available.

### Azure Cosmos DB
Before actually known about this Azure cosmos DB. First breif about this **Cosmos DB**,

 - No SQL Database Store
 - No Relationships between entities
 - No performance overheads like joins
 - No need to define pre - schema

**Azure Cosmos DB** is another popular service used to store data using different DB Service API's.
 
 - Is one of service in Azure
 - Automatically scales in terms of storage
 - automatically scales in terms of compute
 - Also supports many API's - SQL,MongoDB, Cassandra, Tables, Germlin
 - No need to bother about infrastructure like VM - Its a fully serverless service.

