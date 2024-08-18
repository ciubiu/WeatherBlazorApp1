using WeatherBlazorApp1.Models;

namespace WeatherBlazorApp1.Services;

// from C# 12 we can use primary constructor
public class OpenWeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : IWeatherService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OpenWeatherAPI");
    private readonly IConfiguration _configuration = configuration;

    public async Task<WeatherData?> GetWeatherDataAsync(string cityCoordinates)
    {
        var openApiUrl = _configuration["OpenWeatherUrl"];
        var data = await _httpClient.GetFromJsonAsync<WeatherData>($"{openApiUrl}{cityCoordinates}");
        return data;
    }
}
