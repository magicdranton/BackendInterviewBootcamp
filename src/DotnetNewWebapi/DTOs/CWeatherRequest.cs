using System.ComponentModel.DataAnnotations;

namespace DotnetNewWebapi.DTOs
{
    public enum eTemperatureUnit
    {
        Celsius,
        Fahrenheit
    }

    public record RWeatherRequest(
        [Required][StringLength(100)] string City,
        [Range(1, 5)] int? Days
    );

    public record RCreateWeatherRequest(
        [Required][StringLength(100)] string City,
        [Range(1, 5)] int? Days,
        [Range(0, 1)] eTemperatureUnit Unit
    );
}
