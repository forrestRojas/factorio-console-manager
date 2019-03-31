using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FactorioConsoleManagerApp.DAL;

namespace FactorioConsoleManagerApp
{
    public class Startup
    {
        public readonly IServiceProvider serviceProvider;

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

            AppSettingsModel config = configuration.Get<AppSettingsModel>();

            string userAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + '/';
            string appListFilePath = userAppData + config.AppData.Lists;
            string gameListFilePath = userAppData + config.GameData.Lists;


            //setup our DI
            this.serviceProvider = new ServiceCollection()
                .AddSingleton<IModListDAO>(dao => new ModListJsonDAO(appListFilePath, gameListFilePath))
                .BuildServiceProvider();

            var modListDAO = serviceProvider.GetService<IModListDAO>();

        }
    }
}
