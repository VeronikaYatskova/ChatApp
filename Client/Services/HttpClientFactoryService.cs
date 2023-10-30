using System.Text.Json;

namespace ChatApp.Client.Services
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        
        public async Task Execute()
        {
            var httpClient = _httpClientFactory.CreateClient();

            using var response = await httpClient
                .GetAsync("https://localhost:7157/auth");

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var message = await JsonSerializer.DeserializeAsync<string>(stream, _options);
        }

        public async Task<IEnumerable<Guid>> GetUsersChatExecute()
        {
            var httpClient = _httpClientFactory.CreateClient();

            using var response = await httpClient
                .GetAsync("https://localhost:7008/api/chats");

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var users = await JsonSerializer.DeserializeAsync<IEnumerable<Guid>>(stream, _options);

            if (users is null)  throw new ArgumentNullException("No chats");

            return users;
        }
    }
}
