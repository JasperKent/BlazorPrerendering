using BlazorPrerendering.Client.Models;
using BlazorPrerendering.Client.Pages;
using BlazorPrerendering.Client.Services;
using BlazorPrerendering.Client.Tests.Mocks;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace BlazorPrerendering.Client.Tests.Pages;

public class HomeTests : TestContext
{
    private readonly IApiService _apiService = Substitute.For<IApiService>();

    public HomeTests()
    {
        Services.AddSingleton(_apiService);
        Services.AddSingleton<IPersistenceService, MockPersistenceService>();
    }

    [Fact]
    public void Creation()
    {
        var component = RenderComponent<Home>();

        Assert.NotNull(component);
    }

    [Fact]
    public void ListBooks()
    {
        var books = new[]
        {
            new Book { Id = 1, Title = "Book 1", Year = 2001 },
            new Book { Id = 2, Title = "Book 2", Year = 2002 },
            new Book { Id = 3, Title = "Book 3", Year = 2003 },
        };

        _apiService.GetBooks().Returns(books);
        _apiService.GetAuthors().Returns(Array.Empty<Author>());

        var component = RenderComponent<Home>();

        var cells = component.FindAll("table tbody tr td");

        Assert.Collection(cells,
            cell => Assert.Equal("Book 1", cell.TextContent),
            cell => Assert.Equal("2001", cell.TextContent),
            cell => Assert.Equal("Details", cell.TextContent),
            cell => Assert.Equal("Book 2", cell.TextContent),
            cell => Assert.Equal("2002", cell.TextContent),
            cell => Assert.Equal("Details", cell.TextContent),
            cell => Assert.Equal("Book 3", cell.TextContent),
            cell => Assert.Equal("2003", cell.TextContent),
            cell => Assert.Equal("Details", cell.TextContent)
        );
    }

    [Fact]
    public void ListAuthors()
    {
        var authors = new[]
        {
            new Author { Id = 1, FirstName = "Author 1", LastName = "One" },
            new Author { Id = 2, FirstName = "Author 2", LastName = "Two" },
            new Author { Id = 3, FirstName = "Author 3", LastName = "Three" },
        };

        _apiService.GetBooks().Returns([]);
        _apiService.GetAuthors().Returns(authors);

        var component = RenderComponent<Home>();

        var cells = component.FindAll("table tbody tr td");

        Assert.Collection(cells,
            cell => Assert.Equal("Author 1", cell.TextContent),
            cell => Assert.Equal("One", cell.TextContent),
            cell => Assert.Equal("Author 2", cell.TextContent),
            cell => Assert.Equal("Two", cell.TextContent),
            cell => Assert.Equal("Author 3", cell.TextContent),
            cell => Assert.Equal("Three", cell.TextContent)
        );
    }
}
