using Blazored.SessionStorage;
using Blazorise;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct StorageEndpoint
    {
        public const string UploadPhotoFace = "Storage/UploadPhotoFace";
        public const string UploadPhotoGallery = "Storage/UploadPhotoGallery";
        public const string UploadPhotoValidation = "Storage/UploadPhotoValidation";

        public static string DeletePhotoGallery(string IdPhoto) => $"Storage/DeletePhotoGallery?IdPhoto={IdPhoto}";
    }

    public static class StorageApi
    {
        public static async Task Storage_UploadPhotoFace(this HttpClient http, byte[] bytes, ISyncSessionStorageService storage, INotificationService toast)
        {
            var response = await http.Put(StorageEndpoint.UploadPhotoFace, new { MainPhoto = bytes });

            if (response.IsSuccessStatusCode)
            {
                storage.RemoveItem(ProfileEndpoint.Get);
                await http.Profile_Get(storage); //TODO ??

                //RefreshCore.RefreshMenu();
            }

            await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
        }

        public static async Task Storage_UploadPhotoGallery(this HttpClient http, List<byte[]> Streams, ISyncSessionStorageService storage, INotificationService toast)
        {
            var response = await http.Put(StorageEndpoint.UploadPhotoGallery, new { Streams });

            if (response.IsSuccessStatusCode)
            {
                storage.RemoveItem(ProfileEndpoint.Get);
                await http.Profile_Get(storage); //TODO ??
            }

            await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
        }

        public static async Task Storage_DeletePhotoGallery(this HttpClient http, string IdPhoto, ISyncSessionStorageService storage, INotificationService toast)
        {
            var response = await http.Delete(StorageEndpoint.DeletePhotoGallery(IdPhoto));

            if (response.IsSuccessStatusCode)
            {
                storage.RemoveItem(ProfileEndpoint.Get);
                await http.Profile_Get(storage); //TODO ??
            }

            await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
        }

        public static async Task Storage_UploadPhotoValidation(this HttpClient http, byte[] bytes, ISyncSessionStorageService storage, INotificationService toast)
        {
            var response = await http.Put(StorageEndpoint.UploadPhotoValidation, new { Stream = bytes });

            if (response.IsSuccessStatusCode)
            {
                storage.RemoveItem(ProfileEndpoint.Get);
                await http.Profile_Get(storage); //TODO ??
            }

            await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
        }
    }
}