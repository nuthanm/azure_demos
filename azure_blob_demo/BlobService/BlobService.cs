using Azure.Storage.Blobs;
using System;

namespace azure_blob_demo
{
    public class BlobService
    {

        private string _container;
        private string _connectionString;

        private string _blobName;

        public string Container {
             get {
                 return _container;
             }             
              set{
                  _container = value;
              }
        }

        public string ConnectionString {
             get {
                 return _connectionString;
             }
             
              set{
                  _connectionString = value;
              }
        }

        public string BlobName {
             get {
                 return _blobName;
             }             
              set{
                  _blobName = value;
              }
        }

        public void CreateContainerIfNotExists()
        {
            var _blobServiceClient = CreateBlobServiceClient();            
            
                // Option 1:
                 _blobServiceClient.GetBlobContainerClient(this.Container).CreateIfNotExists();

                // Option 2:
                // var _container = _blobServiceClient.GetBlobContainerClient(this.Container);
                // var isExists = _container.Exists();
                // if(!isExists)
                // {
                //     _container.Create();
                //     Console.WriteLine("Blob Container Created Successfully");
                // }
                
                // Option 3:
                // _blobServiceClient.CreateBlobContainer(this.Container);
                // Console.WriteLine("Blob Container Created Successfully");
        }

        public void UploadBlob(string fileLocation)
        {
            try
            {
                 var _blobServiceClient = CreateBlobServiceClient();
               
                 BlobContainerClient _blobContainerClient = _blobServiceClient.GetBlobContainerClient(this.Container);

                 BlobClient _blobClient = _blobContainerClient.GetBlobClient(this.BlobName);

                _blobClient.Upload(fileLocation);

                 Console.WriteLine("Uploaded blob Successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private BlobServiceClient CreateBlobServiceClient()
        {
            return new BlobServiceClient(this.ConnectionString);            
        }        
    }
}