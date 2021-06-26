using Azure.Storage.Blobs;
namespace azure_blob_demo
{
    public class BlobService
    {

        private string _container;
        private string _connectionString;

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

        private BlobServiceClient CreateBlobServiceClient()
        {
            return new BlobServiceClient(this.ConnectionString);            
        }        
    }
}