using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

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
        public static string GetStorageKey(string key) => string.IsNullOrEmpty(IdUser) ? throw new ArgumentException(IdUser) : $"{key}({IdUser})";
        public static string BaseApi => "http://localhost:7071/api/";
    }

    /// <summary>
    /// if you implement the OnInitializedAsync method, call 'await base.OnInitializedAsync();'
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ComponenteCore<T> : ComponentBase where T : class
    {
        [Inject]
        protected ILogger<T> Logger { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IToastService Toast { get; set; }

        [Inject]
        protected ILocalStorageService LocalStorage { get; set; }

        [Inject]
        protected ISessionStorageService SessionStorage { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(ComponenteUtils.IdUser))
                {
                    var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    //ComponenteUtils.IdUser = authState.User.FindFirst(c => c.Type == "sub")?.Value;
                    ComponenteUtils.IdUser = authState.User.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
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

        protected abstract Task LoadData();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await base.OnInitializedAsync();

                await LoadData();
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
        }

        protected void FeatureUnavailable()
        {
            Toast.ShowWarning("Recurso em desenvolvimento. Aguarde novidades...");
        }
    }
}