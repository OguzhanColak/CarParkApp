using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt")
            .WriteTo.Seq("http://localhost:5341/")
            .MinimumLevel.Information() //En d���k mesaj tipini belirtir.
            .Enrich.WithProperty("Application", "CarPark.User") //Kendi property'lerimizi olu�turmam�za olanak sa�lar.
            .Enrich.WithMachineName() // bilgisayar ad�n� g�nderir.
            .CreateLogger();
            
            //admin
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
