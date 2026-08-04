namespace DotnetNewWebapi.Middleware
{
    public static class CExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CExceptionHandlingMiddleware>();
        }
    }

    public class CExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CExceptionHandlingMiddleware> _logger;

        public CExceptionHandlingMiddleware(RequestDelegate next, ILogger<CExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SOME ERROR OCCURED DURING REQUEST PROCESSING !!!");
                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.ContentType = "application/json";
                var errorResponse = new { message = "An unexpected error occurred. Please try again later." };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}