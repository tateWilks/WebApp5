using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApp5.Infrastructure
{
    //basically a tool to convert the cart object to JSON and then back (can't store carts in a session)
    public static class SessionExtensions //gonna use this class to convert data into JSON
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value)); //get data into a txt file so we can pull the data when we need it
        }

        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
