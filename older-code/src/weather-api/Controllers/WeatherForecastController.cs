using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace weatherapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly DaprClient _daprClient;
    private readonly Geo.GeoServices.GeoServicesClient _client;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        DaprClient daprClient,
        Geo.GeoServices.GeoServicesClient client,
        ILogger<WeatherForecastController> logger)
    {
        _daprClient = daprClient;
        _client = client;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("historic")]
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastFromStore(DateTime start, DateTime end, string countryCode)
    {
        var data = new { start, end, countryCode };
        return await _daprClient.InvokeMethodAsync<object, IEnumerable<WeatherForecast>>(
            HttpMethod.Get,
            "weatherstoreapi",
            "WeatherStore",
            data);
    }

    [HttpGet("countries")]
    public IEnumerable<Geo.Country> GetCountries()
    {
        var response = _client.GetCountries(new Geo.CountryRequest());
        return response.Countries;
    }
}
