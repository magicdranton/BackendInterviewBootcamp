using DotnetNewWebapi.DTOs;
using DotnetNewWebapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNewWebapi.Controllers;

[ApiController]
[Route("weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService p_WeatherService)
    {
        _logger = logger;
        _weatherService = p_WeatherService;
    }

    [HttpGet("{city}")]
    public Task<string> GetByCity([FromRoute] RWeatherRequest p_Request)
    {
        return _weatherService.GetWeatherAsync(p_Request);
    }

    [HttpGet]
    public Task<string> GetByCityDays([FromQuery] RWeatherRequest p_Request)
    {
        return _weatherService.GetWeatherAsync(p_Request);
    }


    [HttpPost]
    public Task<string> CreateWeather([FromBody] RCreateWeatherRequest p_Request)
    {
        return _weatherService.CreateWeatherAsync(p_Request);
    }

    [HttpGet("request-info")]
    public ActionResult<string> GetRequestId([FromHeader(Name = "X-Request-Id")] string? p_RequestId)
    {
        if (string.IsNullOrEmpty(p_RequestId)) return BadRequest(); // returning 400 to identify that RequestId is required

        return Ok(p_RequestId);
    }
}
