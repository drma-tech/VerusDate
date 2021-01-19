using Blazored.LocalStorage;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class StorageApi
    {
        public async static Task<HttpResponseMessage> Storage_UploadPhotoFace(this HttpClient http, byte[] bytes, ISyncLocalStorageService storage)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            return await http.Put("Storage/UploadPhotoFace", new { MainPhoto = bytes }, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Storage_UploadPhotoGallery(this HttpClient http, MemoryStream stream1, MemoryStream stream2, MemoryStream stream3, MemoryStream stream4, ISyncLocalStorageService storage)
        {
            return await http.Put("Storage/UploadPhotoGallery", new
            {
                Stream1 = stream1?.ToArray(),
                Stream2 = stream2?.ToArray(),
                Stream3 = stream3?.ToArray(),
                Stream4 = stream4?.ToArray()
            }, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Storage_UploadPhotoValidation(this HttpClient http, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            return await http.Put("Storage/UploadPhotoValidation", new { Stream = bytes }, null, null);
        }
    }
}