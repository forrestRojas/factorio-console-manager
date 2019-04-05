using FactorioConsoleManagerApp.ConsoleLayout.Headers;
using FactorioConsoleManagerApp.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    /// <summary>
    /// Represents a Mod Manager CIL.
    /// </summary>
    public class ModMangerCLI : MasterCLI
    {
        private const int titleWidth = 50;
        private const int titleHeight = 5;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IModListDAO modListDAO;

        public ModMangerCLI(IModListDAO modListDAO)
        {
            this.modListDAO = modListDAO;
        }

        /// <summary>
        /// Runs the ModMenu CLI.
        /// </summary>
        public override void Run()
        {
            log.Info("Running Mod Manager Menu");
            while (!isExit)
            {
                Console.Clear();
                new Header().Title("Mod Manager", titleWidth, titleHeight, "double");
                Console.WriteLine();
                Console.WriteLine("1 - Manage Mod Lists");
                Console.WriteLine("2 - Tweek Mod Files");
                Console.WriteLine("3 - Go Back To Main Menu");
                Console.WriteLine("Q - Quit");

                string userInput = HelperCLI.GetString("Choose One: > ");


                switch (userInput.ToLower())
                {
                    case "1":

                        new ModListCLI(modListDAO).Run();
                        break;
                        
                    case "2":
                        new ModTweekerCLI().Run();
                        break;

                    case "3":
                        return;

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