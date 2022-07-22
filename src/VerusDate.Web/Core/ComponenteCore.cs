using Blazored.SessionStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using VerusDate.Web.Api;

namespace VerusDate.Web.Core
{
    public class VisibilityOptions
    {
        public bool Premium { get; set; }
        public bool Invalid { get; set; }
        public bool Loading { get; set; }
        public bool NoData { get; set; }

        public bool HasCustomVisibility => Premium || Invalid || Loading || NoData;
    }

    public static class ComponenteUtils
    {
        public static string IdUser { get; set; }
        public static bool IsAuthenticated { get; set; }
        public static ISyncSessionStorageService Storage { get; set; }

        //public static string GetStorageKey(string key) => string.IsNullOrEmpty(IdUser) ? throw new ArgumentException(IdUser) : $"{key}({IdUser})";

        public static string BaseApi(this HttpClient http) => http.BaseAddress.ToString().Contains("localhost") ? "http://localhost:7071/api/" : http.BaseAddress.ToString() + "api/";
    }

    /// <summary>
    /// if you implement the OnInitializedAsync method, call 'await base.OnInitializedAsync();'
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public abstract class ComponenteCore<TClass> : ComponentBase where TClass : class
    {
        [Inject]
        protected ILogger<TClass> Logger { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IToastService Toast { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected ISyncSessionStorageService SessionStorage { get; set; }

        public bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(ComponenteUtils.IdUser))
                {
                    var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    var user = authState.User;

                    ComponenteUtils.IsAuthenticated = user.Identity != null && user.Identity.IsAuthenticated;
                    ComponenteUtils.IdUser = user.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    ComponenteUtils.Storage = SessionStorage;
                }
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
        }
    }

    /// <summary>
    /// if you implement the OnInitializedAsync method, call 'await base.OnInitializedAsync();'
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PageCore<T> : ComponenteCore<T> where T : class
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected abstract Task LoadData();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (ComponenteUtils.IsAuthenticated)
                {
                    var principal = await Http.Principal_Get(SessionStorage);

                    //força o cadastro, caso não tenha registrado a conta principal
                    if (principal == null)
                    {
                        Navigation.NavigateTo("/ProfilePrincipal");
                    }
                }

                await base.OnInitializedAsync();

                await LoadData();
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
            finally
            {
                IsLoading = false;
            }
        }

        protected void FeatureUnavailable()
        {
            Toast.ShowWarning("", "Recurso em desenvolvimento. Aguarde novidades...");
        }
    }
}