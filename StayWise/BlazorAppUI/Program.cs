using BlazorAppUI;
using BlazorAppUI.Services;
using BlazorAppUI.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddValidatorsFromAssemblyContaining<HotelValidator>();

// Add a default HttpClient for the self-address
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add a named HttpClient for the Hotels API
builder.Services.AddHttpClient<HotelService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7140/api/hotel/");
});

await builder.Build().RunAsync();
