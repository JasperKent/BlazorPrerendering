using BlazorPrerendering.Data.Models;

namespace BlazorPrerendering.Client.Services
{
    public interface IApiService
    {
        Task<IEnumerable<Book>?> GetBooks();
        Task<IEnumerable<Author>?> GetAuthors();
        Task<Author> CreateAuthor(Author author);

    }
}
