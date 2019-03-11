using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FactorioConsoleManagerApp
{
    public class Startup
    {
        public Startup()
        {
            //setup our DI
            //var serviceProvider = new ServiceCollection()
            //    .AddLogging()
            //    .AddSingleton<IFooService, FooService>()
            //    .AddSingleton<IBarService, BarService>()
            //    .BuildServiceProvider();

            ////configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            //do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();
        }
}
