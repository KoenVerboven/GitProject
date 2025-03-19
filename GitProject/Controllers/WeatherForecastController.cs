using Microsoft.AspNetCore.Mvc;

namespace GitProject.Controllers
{
    //use this url to see json-data : https://localhost:44344/WeatherForecast

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] WheaterSummaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Colder", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Very Very Cold", "Very Very Hot"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

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
