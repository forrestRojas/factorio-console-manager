using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FactorioConsoleManagerApp.DAL;

namespace FactorioConsoleManagerApp
{
    public class Startup
    {
        public Startup()
        {
            Action<Exception> ErrorHandler = (ex) => {
                // TODO LOG exception GetModLists method then pass up the chain
            };


            //setup our configuration
            try
            {

            }
            catch (IOException)
            {

                throw;
            }

            //setup our DI
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IModListDAO>(dao => new ModListJsonDAO())
                .BuildServiceProvider();

            // TODO configure console logging


            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            do the actual work here
            var bar = serviceProvider.GetService<IBarService>();
        }
    }
}
