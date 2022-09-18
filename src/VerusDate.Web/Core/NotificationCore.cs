using Blazored.Toast.Services;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Core
{
    public static class NotificationCore
    {
        public static async Task ProcessResponse(this HttpResponseMessage response, IToastService? toast = null, string? msgSuccess = null, string? msgInfo = null)
        {
            var msg = await response.Content.ReadAsStringAsync();

            if ((short)response.StatusCode >= 100 && (short)response.StatusCode <= 199) //Provisional response
            {
                //do nothing
            }
            else if ((short)response.StatusCode >= 200 && (short)response.StatusCode <= 299) //Successful
            {
                if (!string.IsNullOrEmpty(msgSuccess)) toast?.ShowSuccess("", msgSuccess);
                if (!string.IsNullOrEmpty(msgInfo)) toast?.ShowInfo("", msgInfo);
            }
            else if ((short)response.StatusCode >= 300 && (short)response.StatusCode <= 399) //Redirected
            {
                throw new NotificationException(msg);
            }
            else if ((short)response.StatusCode >= 400 && (short)response.StatusCode <= 499) //Request error
            {
                throw new NotificationException(msg);
            }
            else //Server error
            {
                throw new InvalidOperationException(msg);
            }
        }

        public static void ProcessException(this Exception ex, IToastService toast, ILogger logger)
        {
            if (ex is NotificationException)
            {
                logger.LogWarning(ex, null);
                toast.ShowWarning("", ex.Message);
            }
            else
            {
                logger.LogError(ex, null);
                toast.ShowError("", ex.Message);
            }
        }
    }
}