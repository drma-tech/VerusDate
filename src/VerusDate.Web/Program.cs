using AzureStaticWebApps.Blazor.Authentication;
using Blazored.SessionStorage;
using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VerusDate.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddBlazorise(options => options.Immediate = true)
    .AddBootstrapProviders()
    .AddFontAwesomeIcons()
    .AddBlazoredToast();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddStaticWebAppsAuthentication();

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredSessionStorage(config => config.JsonSerializerOptions.WriteIndented = true);

//builder.Services.AddOidcAuthentication(options =>
//{
//    // Configure your authentication provider options here.
//    // For more information, see https://aka.ms/blazor-standalone-auth
//    builder.Configuration.Bind("Local", options.ProviderOptions);
//});

await builder.Build().RunAsync();