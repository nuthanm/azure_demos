using System;
namespace azure_blob_demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var blobService = new BlobService();
            blobService.Container = "temp";
            blobService.ConnectionString = "<Your_Blob_ConnectionString>";
            blobService.BlobName = "template.txt";

            try
            {
                // Creete a new container if not exists
                blobService.CreateContainerIfNotExists();
                // blobService.UploadBlob(@"C:\Users\Administrator\Downloads\template.txt");
                var itemNames = blobService.GetListOfBlobs();

                foreach (var item in itemNames)
                {
                    Console.WriteLine(item);
                }

                blobService.DownloadBlob($@"C:\Users\Administrator\Downloads\{blobService.BlobName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blob Container Fail to create." + ex.Message);
            }
        }
    }
}
