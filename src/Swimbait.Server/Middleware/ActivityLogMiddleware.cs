﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Swimbait.Server.Services;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using System.IO;

namespace Swimbait.Server
{
    /// <summary>
    /// Fluent extension
    /// </summary>
    public static class ActivityLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseActivityLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActivityLogMiddleware>();
        }
    }

    public class ActivityLogMiddleware
    {
        private readonly RequestDelegate next;
        static object _lockObject = new object();

        public ActivityLogMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var uri = request.GetUri();
            var path = uri.PathAndQuery;

            var debugFolder = @"D:\Downloads\swimbait";
            Directory.CreateDirectory(debugFolder);
            var filename = Path.Combine(debugFolder, "activity.txt");
            
            var thisPort = uri.Port;
            var yamahaPort = MapPortToReal(uri);

            var body = "<not decoded>";
            if (!uri.ToString().Contains("secure") && request.Method.ToLower() == "post")
            {
                body = request.Form.Keys.First();
            }

            var lineContent = $"{thisPort},{yamahaPort},{request.Method},{path},{body},{Environment.NewLine}";

            lock (_lockObject)
            {
                File.AppendAllText(filename, lineContent);
            }

            return next(context);
        }


        public static int MapPortToReal(Uri thisRequest)
        {
            // remap the port since windows is using 49154
            const int realYamahaPort = 49154;
            var relayPort = thisRequest.Port == MusicCastHost.DlnaHostPort ? realYamahaPort : thisRequest.Port;
            return relayPort;
        }
    }
}