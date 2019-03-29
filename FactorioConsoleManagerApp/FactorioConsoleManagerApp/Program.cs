using FactorioConsoleManagerApp.CLI;
using System;

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

            Startup startup = new Startup();
            new MainMenuCLI().Run();
            log.Info("Application End\n");
        }
    }
}
