using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
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
            // TODO Make the app allow the user to change the folder paths??

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            AppConfig config = configuration.Get<AppConfig>();

            string userAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + '/';
            string appListString = userAppData + config.AppData.PathStrings.Dirs.Data;


            //setup our DI
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IModListDAO>(dao => new ModListJsonDAO())
                .BuildServiceProvider();
            // TODO configure console logging


            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            //do the actual work here
            var bar = serviceProvider.GetService<IBarService>();
        }
    }
}
