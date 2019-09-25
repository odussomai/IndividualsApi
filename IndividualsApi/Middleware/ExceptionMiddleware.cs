using IndividualsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IndividualsApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IStringLocalizer<ExceptionMiddleware> _localizer;

        public ExceptionMiddleware(RequestDelegate next, 
                                   ILogger<ExceptionMiddleware> logger, 
                                   IStringLocalizer<ExceptionMiddleware> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = _localizer["Internal Error"]
            }.ToString());
        }
    }
}
