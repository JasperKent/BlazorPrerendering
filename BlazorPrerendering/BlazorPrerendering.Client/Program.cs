using BlazorPrerendering.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IPersistenceService, PersistenceService>();

builder.Services.AddHttpClient<IApiService, ApiService>(
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    );

await builder.Build().RunAsync();
