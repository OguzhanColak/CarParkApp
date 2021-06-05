using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
            //    .Build();


            var client = new MongoClient("mongodb+srv://oguzhancolak22:carpark@carparkcluster.m9jcz.mongodb.net/CarParkDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("CarParkDB");


            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.MSSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarParkLog;Persist Security Info=True;", 
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" , AutoCreateSqlTable = true})
                .WriteTo.MongoDB(database, LogEventLevel.Debug, "Log", 1)
                .WriteTo.Seq("http://localhost:5341/")
                .Enrich.WithProperty("Application", "CarPark.User") 
                .Enrich.WithMachineName()
                .CreateLogger();

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
