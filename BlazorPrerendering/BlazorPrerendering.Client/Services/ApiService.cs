using BlazorPrerendering.Data.Models;
using System.Net.Http.Json;

namespace BlazorPrerendering.Client.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Author>?> GetAuthors()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Author>>("/api/authors");
        }

        public Task<IEnumerable<Book>?> GetBooks()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Book>>("/api/books");
        }
    }
}
