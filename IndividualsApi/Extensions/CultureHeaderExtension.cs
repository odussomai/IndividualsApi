using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualsApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace IndividualsApi.Extensions
{
    public static class CultureHeaderExtension
    {
        public static IApplicationBuilder UseCultureHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureHeaderMiddleware>();
        }
    }
}
