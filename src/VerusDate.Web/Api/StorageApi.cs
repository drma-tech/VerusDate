using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class StorageApi
    {
        public async static Task<HttpResponseMessage> Storage_UploadPhotoFace(this HttpClient http, byte[] bytes, ISyncSessionStorageService storage)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            return await http.Put<ProfileModel>("Storage/UploadPhotoFace", new { MainPhoto = bytes }, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Storage_UploadPhotoGallery(this HttpClient http, List<byte[]> Streams, ISyncSessionStorageService storage)
        {
            return await http.Put<ProfileModel>("Storage/UploadPhotoGallery", new { Streams }, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Storage_UploadPhotoValidation(this HttpClient http, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            return await http.Put<ProfileModel>("Storage/UploadPhotoValidation", new { Stream = bytes }, null, null);
        }
    }
}