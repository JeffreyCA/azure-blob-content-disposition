using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SpleeterContentDisposition
{
    public static class SpleeterContentDisposition
    {
        [FunctionName("SpleeterContentDisposition")]
        async public static Task Run([BlobTrigger("media/separate/{uuid}/{name}", Connection = "spleeterstorage_STORAGE")] ICloudBlob myBlob, string uuid, string name, ILogger log)
        {
            if (myBlob.Properties.ContentDisposition != "attachment")
            {
                myBlob.Properties.ContentDisposition = "attachment";
                await myBlob.SetPropertiesAsync();
                log.LogInformation($"C# Blob trigger function processed blob:{name}");
            }

            log.LogInformation($"C# Blob trigger function skipped blob:{name}");
        }
    }
}
