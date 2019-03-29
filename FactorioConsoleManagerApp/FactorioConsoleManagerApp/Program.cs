﻿using FactorioConsoleManagerApp.CLI;
using FactorioConsoleManagerApp.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log.config", Watch = true)]

namespace FactorioConsoleManagerApp
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Application Start");
            Console.Title = "Factorio Console Manager";

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
            // TODO Check if path exists and handle it
            string appListJsonPath = userAppData + config.AppData.PathStrings.Dirs.Data + config.AppData.PathStrings.Files.Lists;
            string gameListJsonPath = userAppData + config.GameData.PathStrings.Dirs.Mods + config.GameData.PathStrings.Files.Lists;
            Path.Combine(;

            //setup our DI
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IModListDAO>(dao => new ModListJsonDAO(appListJsonPath, gameListJsonPath))
                .BuildServiceProvider();

            IModListDAO modListDAO = serviceProvider.GetService<IModListDAO>();

            new MainMenuCLI().Run();
            log.Info("Application End\r\n");
        }
    }
}
