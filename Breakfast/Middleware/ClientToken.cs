using Breakfast.Models;
using Breakfast.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Middleware
{
    public class ClientToken
    {

        RequestDelegate next;

        public ClientToken(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, BreakfastDbContext breakfastContext)
        {
            var cookieId = context.Request.GetClientToken();
            if (cookieId == null)
            {
                var guid = Guid.NewGuid().ToString();
                context.Response.Cookies.Append("ClientToken", guid);
                breakfastContext.Clients.Add(new Client { ClientToken = guid });
                breakfastContext.SaveChanges();

            }
            await next.Invoke(context);
        }


    }

    public static class ClientTokenExtension
    {
        public static IApplicationBuilder UseClientToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientToken>();
        }
    }
}
