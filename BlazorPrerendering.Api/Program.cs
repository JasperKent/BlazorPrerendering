using BlazorPrerendering.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/api/Books", (ILoggerFactory loggerFactory) =>
{
    loggerFactory
        .CreateLogger("MinimalApi")
        .LogInformation("Get for Books called");

    return DummyData.Books;
});

app.MapGet("/api/Authors", (ILoggerFactory loggerFactory) =>
{
    loggerFactory
        .CreateLogger("MinimalApi")
        .LogInformation("Get for Authors called");

    return DummyData.Authors;
});

app.Run();


