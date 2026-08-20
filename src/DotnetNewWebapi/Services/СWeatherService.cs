using DotnetNewWebapi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNewWebapi.Services;

public interface IWeatherService
{
    public Task<string> GetWeatherAsync(RWeatherRequest p_Request);
    public Task<string> CreateWeatherAsync(RCreateWeatherRequest p_Request);
}

public class CWeatherService: IWeatherService
{
    ILogger<CWeatherService> m_Logger;

    public CWeatherService(ILogger<CWeatherService> p_logger)
    {
        m_Logger = p_logger;
    }

    public async Task<string> GetWeatherAsync(RWeatherRequest p_Request)
    {
        try
        {
            m_Logger.LogInformation("GetWeatherAsync for {city} started", p_Request.City);

            await Task.Delay(5000);

            if (string.IsNullOrWhiteSpace(p_Request.City)) throw new Exception("City is required");

            string v_Result = $"weather in {p_Request.City}" + (p_Request.Days == null? string.Empty: $" for {p_Request.Days} days ") + " is GOOD!";

            m_Logger.LogInformation("GetWeatherAsync finished with result: {Result}", v_Result);            
            return v_Result;
        }
        catch (Exception e)
        {
            m_Logger.LogError(e, "GetWeatherAsync failed with error: {message}", e.Message);
            return e.Message;
        }
    }

    public async Task<string> CreateWeatherAsync(RCreateWeatherRequest p_Request)
    {
        try
        {
            m_Logger.LogInformation("CreateWeatherAsync for {city} started", p_Request.City);

            await Task.Delay(5000);

            string v_Result = $"weather in {p_Request.City}" + (p_Request.Days == null ? string.Empty : $" for {p_Request.Days} days ") + 
                $" updated with  {p_Request.Unit}";

            m_Logger.LogInformation("GetWeatherAsync finished with result: {Result}", v_Result);
            return v_Result;
        }
        catch (Exception e)
        {
            m_Logger.LogError(e, "CreateWeatherAsync failed with error: {message}", e.Message);
            return e.Message;
        }
    }
}
