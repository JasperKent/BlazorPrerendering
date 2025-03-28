using BlazorPrerendering.Client.Models;

namespace BlazorPrerendering.Client.Services
{
    public interface IApiService
    {
        Task<IEnumerable<Book>?> GetBooks();
        Task<IEnumerable<Author>?> GetAuthors();
    }
}
