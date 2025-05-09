var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.BlazorPrerendering_Api>("blazorprerendering-api");

var host = builder.AddProject<Projects.BlazorPrerendering>("blazorprerendering")
                  .WithReference(api)
                  .WaitFor(api);

host.WithUrl($"{host.GetEndpoint("https")}/swagger", "Swagger")
    .WithUrlForEndpoint("https", url => url.DisplayText = "Blazor");

builder.Build().Run();
