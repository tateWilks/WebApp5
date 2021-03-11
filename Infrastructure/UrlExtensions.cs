using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Infrastructure
{
    public static class UrlExtensions
    { //http request is passed in and we generate a URL to return to the browser after the cart is updated
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString(); //if the request query string has a value, then we make that the path, otherwise it's just the path
    }
}
