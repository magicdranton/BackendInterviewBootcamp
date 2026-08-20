using System.ComponentModel.DataAnnotations;

namespace DotnetNewWebapi.DTOs
{
    public record RWeatherRequest(
        [Required][StringLength(100)] string City,
        [Range(1, 5)] int? Days
    );

    public record RCreateWeatherRequest(
        [Required][StringLength(100)] string City,
        [Range(1, 5)] int? Days,
        [Required][RegularExpression("^(Celsius|Fahrenheit)$")] string Unit
    );
}
