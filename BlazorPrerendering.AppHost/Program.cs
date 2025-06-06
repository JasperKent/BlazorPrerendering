var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("sql-server")
                .WithDataVolume("library-data")
                .WithLifetime(ContainerLifetime.Persistent)
                .AddDatabase("LibraryDb");

var api = builder.AddProject<Projects.BlazorPrerendering_Api>("blazorprerendering-api")
                 .WithReference(db)
                 .WaitFor(db);

var host = builder.AddProject<Projects.BlazorPrerendering>("blazorprerendering")
                  .WithExternalHttpEndpoints()
                  .WithReference(api)
                  .WaitFor(api);

host.WithUrl($"{host.GetEndpoint("https")}/swagger", "Swagger")
    .WithUrlForEndpoint("https", url => url.DisplayText = "Blazor");

builder.Build().Run();
