using BlazorPrerendering.Data.Models;
using System.Net.Http.Json;

namespace BlazorPrerendering.Client.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<IEnumerable<Author>?> GetAuthors()
        {
            _logger.LogInformation("GetAuthors called");

            return _httpClient.GetFromJsonAsync<IEnumerable<Author>>("/api/authors");
        }

        public Task<IEnumerable<Book>?> GetBooks()
        {
            _logger.LogInformation("GetBooks called");

            return _httpClient.GetFromJsonAsync<IEnumerable<Book>>("/api/books");
        }
    }
}
