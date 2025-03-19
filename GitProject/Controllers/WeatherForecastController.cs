using Microsoft.AspNetCore.Mvc;

namespace GitProject.Controllers
{
    //use this url to see json-data : https://localhost:44344/WeatherForecast

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] WheaterSummaries =
        [
            "Freezing", "Bracing", "Chilly", "Colder", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Very Very Cold", "Very Very Hot"
        ];

        private readonly ILogger<WeatherForecastController> _logger = logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WheaterSummaries[Random.Shared.Next(WheaterSummaries.Length)]
            })
            .ToArray();
        }
    }
}
