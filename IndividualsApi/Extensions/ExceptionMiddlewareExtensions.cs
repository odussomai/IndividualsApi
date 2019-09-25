using IndividualsApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace IndividualsApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }


    }
}
