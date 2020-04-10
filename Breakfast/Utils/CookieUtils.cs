using Breakfast.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Utils
{
    public static class CookieUtils
    {
        public static string GetClientToken(this HttpRequest request)
        {
            var cookieId = request.Cookies["ClientToken"];
            return cookieId;
        }

        public static Client GetClient(this HttpRequest request, BreakfastDbContext context)
        {
            var client = context.Clients.Where(a => a.ClientToken == GetClientToken(request)).FirstOrDefault();
            return client;
        }

    }
}
