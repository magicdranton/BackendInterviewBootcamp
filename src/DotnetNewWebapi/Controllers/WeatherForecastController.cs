using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DotnetNewWebapi.Services;

namespace DotnetNewWebapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService p_WeatherService)
    {
        _logger = logger;
        _weatherService = p_WeatherService;
    }

    [HttpGet("GetCityWeather")]
    public async Task<string> Get(string p_City)
    {
        return await _weatherService.GetWeatherAsync(p_City);
    }
}
