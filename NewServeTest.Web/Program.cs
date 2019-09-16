using System;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NewServeTest.Logger;

namespace NewServeTest.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseIIS()
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddFile(opts =>
                    {
                        context.Configuration.GetSection("FileLoggingOptions").Bind(opts);
                    });
                })
                .UseStartup<Startup>();
    }
}
