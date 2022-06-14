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

    [HttpGet("historic")]
    public IEnumerable<WeatherInfo> Get(DateTime start, DateTime end, string countryCode)
    {
        // Todo: Add validation for start and end dates, in the for loop.
        var infos = new List<WeatherInfo>();
        for (var s = start; s < end; s.AddDays(1))
        {
            var info = new WeatherInfo
            {
                Date = s,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                CountryCode = countryCode
            };
            infos.Add(info);
        }

        return infos;
    }
}
