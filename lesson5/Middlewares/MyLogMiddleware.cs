using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public class MyLogMiddleware
    {
        private readonly RequestDelegate next;
        private string filePath;

        public MyLogMiddleware(RequestDelegate next, IWebHostEnvironment webHost)
        {
            this.next = next;
            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "Log.txt");
            
        }
        public async Task Invoke(HttpContext c)
        {
            var sw = new Stopwatch();
            sw.Start();
            await next.Invoke(c);
            File.AppendAllText(filePath, ($"{c.Request.Path}.{c.Request.Method} took {sw.ElapsedMilliseconds}ms."
                + $" User: {c.User?.FindFirst("userId")?.Value ?? "unknown"}"));
        }

    }
    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyLogMiddleware>();
        }
    }
}