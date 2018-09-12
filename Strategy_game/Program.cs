using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Strategy_game.ServiceInterfaces;
using Strategy_game.Services;

namespace Strategy_game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateWebHostBuilder(args).Build();
            
            //CreateWebHostBuilder(args).Build().Run();
            
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
