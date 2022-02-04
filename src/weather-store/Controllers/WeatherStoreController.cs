using Microsoft.AspNetCore.Mvc;

namespace weather_store.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherStoreController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly",
        "Cool", "Mild", "Warm", "Balmy",
        "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherStoreController> _logger;

    public WeatherStoreController(ILogger<WeatherStoreController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherInfo> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherInfo
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            CountryName = "India"
        })
        .ToArray();
    }
}
