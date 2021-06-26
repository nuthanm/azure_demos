using System;
namespace azure_blob_demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var blobService = new BlobService();
            blobService.Container ="temp";
            blobService.ConnectionString ="BlobEndpoint=https://az204learning.blob.core.windows.net/;QueueEndpoint=https://az204learning.queue.core.windows.net/;FileEndpoint=https://az204learning.file.core.windows.net/;TableEndpoint=https://az204learning.table.core.windows.net/;SharedAccessSignature=sv=2020-02-10&ss=b&srt=sco&sp=rwdlactf&se=2021-06-28T15:26:58Z&st=2021-06-26T07:26:58Z&spr=https&sig=%2BKH27DU8tKdOFhm1oAPJWl4Uny041wkEVaT71wHgnpw%3D";

            try
            {
                // Creete a new container if not exists
                blobService.CreateContainerIfNotExists();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Blob Container Fail to create." + ex.Message);
            }
        }
    }
}
