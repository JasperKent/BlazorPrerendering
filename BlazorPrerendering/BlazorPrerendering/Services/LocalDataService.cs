using BlazorPrerendering.Client.Models;
using BlazorPrerendering.Client.Services;
using BlazorPrerendering.Data;

namespace BlazorPrerendering.Services
{
    public class LocalDataService : IApiService
    {
        public Task<IEnumerable<Author>?> GetAuthors()
        {
            return Task.FromResult<IEnumerable<Author>?>(DummyData.Authors);
        }

        public Task<IEnumerable<Book>?> GetBooks()
        {
            return Task.FromResult<IEnumerable<Book>?>(DummyData.Books);
        }
    }
}
