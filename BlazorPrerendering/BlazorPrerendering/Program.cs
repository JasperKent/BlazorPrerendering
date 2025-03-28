using BlazorPrerendering.Client.Services;
using BlazorPrerendering.Components;
using BlazorPrerendering.Data;
using BlazorPrerendering.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddTransient<IPersistenceService, PersistenceService>();

builder.Services.AddScoped<IApiService, LocalDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorPrerendering.Client._Imports).Assembly);

app.MapGet("/api/Books", (IApiService dataSource) =>
{
    return dataSource.GetBooks();
});

app.MapGet("/api/Authors", (IApiService dataSource) =>
{
    return dataSource.GetAuthors();
});

app.Run();
