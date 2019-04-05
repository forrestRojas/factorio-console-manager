using FactorioConsoleManagerApp.ConsoleLayout.Headers;
using FactorioConsoleManagerApp.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    /// <summary>
    /// Represents a MainMenuCLI.
    /// </summary>
    public class MainMenuCLI : MasterCLI
    {
        private const int titleWidth = 50;
        private const int titleHeight = 5;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IModListDAO modListDAO;

        public MainMenuCLI(IModListDAO modListDAO)
        {
            this.modListDAO = modListDAO;
        }

        /// <summary>
        /// Runs the Main Menu.
        /// </summary>
        public override void Run()
        {
            log.Info("Running Main Menu");
            while (!isExit)
            {

                Console.Clear();
                new Header().Title("Welcome to the Factorio Console Manager!", titleWidth, titleHeight, "double");
                Console.WriteLine();
                Console.WriteLine("1 - Mod Manager");
                Console.WriteLine("2 - Ratio Calculator");
                Console.WriteLine("Q - Quit");

                string userInput = HelperCLI.GetString("Choose One: > ");

                switch (userInput.ToLower())
                {
                    case "1":
                        new ModMangerCLI(modListDAO).Run();
                        break;

                    case "2":
                        new RatioCalculatorCLI().Run();
                        break;
                        
                    case "q":
                        isExit = true;
                        return;

                    default:
                        break;
                }
            }
        }
    }
}
