using Microsoft.AspNetCore.Mvc;

namespace DotnetNewWebapi.Services;

public interface IWeatherService
{
    public Task<string> GetWeatherAsync(string p_city);
}

public class CWeatherService: IWeatherService
{
    ILogger<CWeatherService> m_Logger;

    public CWeatherService(ILogger<CWeatherService> p_logger)
    {
        m_Logger = p_logger;
    }

    public async Task<string> GetWeatherAsync(string p_city)
    {
        try
        {
            m_Logger.LogInformation("GetWeatherAsync for {city} started", p_city);

            await Task.Delay(5000);

            throw new Exception("general exc");

            string v_Result = $"weather in {p_city} is GOOD!";

            m_Logger.LogInformation("GetWeatherAsync finished with result: {Result}", v_Result);
            return v_Result;
        }
        catch (Exception e)
        {
            m_Logger.LogError("GetWeatherAsync failed with error: {error}", e);
            return string.Empty;
        }
    }
}
