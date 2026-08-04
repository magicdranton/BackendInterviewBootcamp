using System.Diagnostics;

namespace DotnetNewWebapi.Middleware;
public class CRequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CRequestTimingMiddleware> _logger;

    public CRequestTimingMiddleware(RequestDelegate next, ILogger<CRequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Register the callback BEFORE calling the next middleware component
        context.Response.OnStarting(() => {
            stopwatch.Stop();

            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            _logger.LogInformation("Request {Method} {Path} executed in {ElapsedMilliseconds} ms",
                context.Request.Method, context.Request.Path, elapsedMilliseconds);

            context.Response.Headers.TryAdd("X-Execution-Time", elapsedMilliseconds.ToString());
            return Task.CompletedTask;
        });
        
        await _next(context);        
    }
}

public static class CRequestTimingMiddlewareExtensions
{
    public static IApplicationBuilder UseCRequestTiming(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CRequestTimingMiddleware>();
    }
}