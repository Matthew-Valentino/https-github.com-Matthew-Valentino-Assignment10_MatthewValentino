using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bank4Us.ServiceApp
{
    public class Program
    {
        /// <summary>
        ///   COSC 6360 Enterprise Architecture
        ///   Year: Fall 2023
        ///   Name: Matthew Valentino
        ///   Description: Assignment 9 focusing on creating a service application           
        /// </summary>
        /// 
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
