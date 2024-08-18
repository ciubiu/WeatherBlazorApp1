using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using WeatherBlazorApp1.Models;
using WeatherBlazorApp1.Services;

namespace WeatherBlazorApp1.Tests;

public class OpenWeatherServiceTests
{
    [Fact]
    public async Task GetWeatherDataAsync_ReturnsWeatherData()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var mockConfiguration = new Mock<IConfiguration>();

        var expectedWeatherData = new WeatherData
        {
            //"latitude": 52.52,
            //"longitude": 13.419998,
            //"generationtime_ms": 0.06794929504394531,
            //"utc_offset_seconds": 7200,
            //"timezone": "Europe/Berlin",
            //"timezone_abbreviation": "CEST",
            //"elevation": 38.0,
            //"current_units": {
            //  "time": "iso8601",
            //  "interval": "seconds",
            //  "temperature_2m": "°C",
            //  "precipitation_probability": "%",
            //  "wind_speed_10m": "km/h"
            //},
            //"current": {
            //  "time": "2024-08-18T13:00",
            //  "interval": 900,
            //  "temperature_2m": 23.0,
            //  "precipitation_probability": 32,
            //  "wind_speed_10m": 6.6
            //}

            Latitude = 52.52,
            Longitude = 13.419998,
            GenerationtimeMs = 0.06794929504394531,
            UtcOffsetSeconds = 7200,
            Timezone = "Europe/Berlin",
            TimezoneAbbreviation = "CEST",
            Elevation = 38.0,
            CurrentUnits = new CurrentUnits
            {
                Time = "iso8601",
                Interval = "seconds",
                Temperature2m = "°C",
                PrecipitationProbability = "%",
                WindSpeed10m = "km/h"
            },
            Current = new Current
            {
                Time = "2024-08-18T13:00",
                Interval = 900,
                Temperature2m = 23.0,
                PrecipitationProbability = 32,
                WindSpeed10m = 6.6
            }
        };

        var cityCoordinates = "&latitude = 59.4370 & longitude = 24.7536";
        var openApiUrl = "http://api.openweathermap.org/data/2.5/weather?q=";

        mockConfiguration.Setup(c => c["OpenWeatherUrl"]).Returns(openApiUrl);

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(expectedWeatherData)),
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory.Setup(f => f.CreateClient("OpenWeatherAPI")).Returns(httpClient);

        var service = new OpenWeatherService(mockHttpClientFactory.Object, mockConfiguration.Object);

        // Act
        var result = await service.GetWeatherDataAsync(cityCoordinates);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedWeatherData.Current.Temperature2m, result.Current.Temperature2m);
        // Add more assertions as needed
    }

}


