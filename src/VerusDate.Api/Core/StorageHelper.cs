using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VerusDate.Api.Core
{
    public class StorageHelper
    {
        public IConfiguration Configuration { get; }

        public enum PhotoType
        {
            PhotoFace,
            PhotoGallery,
            PhotoValidation
        }

        private static string getContainer(PhotoType type)
        {
            return type switch
            {
                PhotoType.PhotoFace => "photo-face",
                PhotoType.PhotoGallery => "photo-gallery",
                PhotoType.PhotoValidation => "photo-validation",
                _ => throw new InvalidOperationException(nameof(PhotoType)),
            };
        }

        public StorageHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task UploadPhoto(PhotoType type, Stream stream, string id)
        {
            var container = new BlobContainerClient(Configuration.GetConnectionString("AzureStorage"), getContainer(type));
            var blob = container.GetBlobClient(id + ".jpg");

            var headers = new BlobHttpHeaders { ContentType = "image/jpeg" };

            await blob.UploadAsync(stream, httpHeaders: headers);
        }

        public async Task DeletePhoto(PhotoType type, string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            var container = new BlobContainerClient(Configuration.GetConnectionString("AzureStorage"), getContainer(type));
            var blob = container.GetBlobClient(fileName);

            if (await blob.ExistsAsync())
            {
                await blob.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots);
            }
        }
    }
}