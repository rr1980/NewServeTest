using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace NewServeTest.Web
{
    public static class RequestMiddlewareExtension
    {
        public static void UseRequestMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestMiddleware>();
        }
    }

    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _options;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;

            _options = new JsonSerializerOptions
            {
                WriteIndented = true
            };


        }

        public async Task InvokeAsync(HttpContext context)
        {
            var r = context.Request;
            var tmp = JsonSerializer.ToString(
                new
                {
                    r.Scheme,
                    r.Host,
                    r.Path,
                    r.QueryString,
                    //Headers = r.Headers,
                    r.Method,
                    r.ContentType,
                    r.Protocol,
                    //RouteValues = r.RouteValues
                }, _options);


            //using (StreamWriter writer = new StreamWriter(_fileStream))
            //{
            //    await writer.WriteAsync(tmp + Environment.NewLine);
            //}

            //Debug.WriteLine("Scheme",context.Request.Scheme);
            //Debug.WriteLine("Host", context.Request.Host);
            //Debug.WriteLine("Path", context.Request.Path);
            //Debug.WriteLine("QueryString", context.Request.QueryString);
            //Debug.WriteLine("Headers", context.Request.Headers);
            //Debug.WriteLine("Method", context.Request.Method);
            //Debug.WriteLine("ContentType", context.Request.ContentType);
            //Debug.WriteLine("Protocol", context.Request.Protocol);
            //Debug.WriteLine("RouteValues", context.Request.RouteValues);

            await _next(context);
        }
    }
}
