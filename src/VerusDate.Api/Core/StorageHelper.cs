using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Api.Core
{
    public class StorageHelper
    {
        public IConfiguration Configuration { get; }

        public StorageHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task UploadPhoto(PhotoType type, Stream stream, string fileName, CancellationToken cancellationToken)
        {
            var container = new BlobContainerClient(Configuration.GetValue<string>("AzureStorage"), GetPhotoContainer(type));
            var client = container.GetBlobClient(fileName);

            var headers = new BlobHttpHeaders { ContentType = "image/jpeg" };

            await client.UploadAsync(stream, headers, cancellationToken: cancellationToken);
        }

        public async Task DeletePhoto(PhotoType type, string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            var container = new BlobContainerClient(Configuration.GetValue<string>("AzureStorage"), GetPhotoContainer(type));
            var blob = container.GetBlobClient(fileName);

            if (await blob.ExistsAsync())
            {
                await blob.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots);
            }
        }
    }
}