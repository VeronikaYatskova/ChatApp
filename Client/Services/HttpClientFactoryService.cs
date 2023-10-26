using System.Text.Json;

namespace Client.Services
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
    }
}
