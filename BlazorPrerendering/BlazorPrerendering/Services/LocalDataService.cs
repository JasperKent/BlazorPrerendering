using BlazorPrerendering.Client.Services;
using BlazorPrerendering.Data.Models;

namespace BlazorPrerendering.Services
{
    public class LocalDataService : IApiService
    {
        public Task<IEnumerable<Author>?> GetAuthors()
        {
            return Task.FromResult<IEnumerable<Author>?>([]);
        }

        public Task<IEnumerable<Book>?> GetBooks()
        {
            return Task.FromResult<IEnumerable<Book>?>([]);
        }
    }
}
