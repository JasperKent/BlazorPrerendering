using BlazorPrerendering.Api.Data;
using BlazorPrerendering.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddSqlServerDbContext<LibraryContext>("LibraryDb");

var app = builder.Build();

CreateData();

app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/api/Books", (ILoggerFactory loggerFactory, LibraryContext db) =>
{
    loggerFactory
        .CreateLogger("MinimalApi")
        .LogInformation("Get for Books called");

    return db.Books;
});

app.MapGet("/api/Authors", (ILoggerFactory loggerFactory, LibraryContext db) =>
{
    loggerFactory
        .CreateLogger("MinimalApi")
        .LogInformation("Get for Authors called");

    return db.Authors;
});

app.MapPost("/api/Authors", async (Author author, ILoggerFactory loggerFactory, LibraryContext db) =>
{
    loggerFactory
        .CreateLogger("MinimalApi")
        .LogInformation("Post for Authors called");
        
    db.Authors.Add(author);
    
    await db.SaveChangesAsync();
    
    return Results.Created($"/api/Authors/{author.Id}", author);
});

app.Run();


void CreateData()
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();

    db.Database.Migrate();

    if (!db.Books.Any())
        db.Books.AddRange(DummyData.Books);

    if (!db.Authors.Any())
    {
        db.Authors.AddRange(DummyData.Authors);
        db.Authors.Add(new() { FirstName = "Jasper", Surname = "Kent" });
    }

    db.SaveChanges();
}