using WeatherBlazorApp1.Models;

namespace WeatherBlazorApp1.Services;

public interface IWeatherService
{
    Task<WeatherData?> GetWeatherDataAsync(string cityCoordinates);
}
