using FactorioConsoleManagerApp.ConsoleLayout.Headers;
using FactorioConsoleManagerApp.DAL;
using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    /// <summary>
    /// Represents the ModListCLI
    /// </summary>
    public class ModListCLI : MasterCLI
    {
        private const int titleWidth = 100;
        private const int titleHeight = 5;

        private readonly IModListDAO modListDAO;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public ModListCLI()
        {
            this.modListDAO = new ModListJsonDAO("C:/Users/Forrest/AppData/Roaming/Factorio/mods/mod-list.json", "C:/Users/Forrest/AppData/Roaming/Factorio/mods/mod-list.json");
        }

        /// <summary>
        /// Runs the ModListCLI
        /// </summary>
        public override void Run()
        {
            log.Info("Running Mod List Menu");
            while (!isExit)
            {
                Console.Clear();
                new Header().Title("Mod Lists", titleWidth, titleHeight, "double");
                Console.WriteLine();
                // Display modlist and active list
                this.DisplayModLists();
                Console.WriteLine("1 - Choose a list");
                Console.WriteLine("2 - Go Back To Mod Manger Menu");
                Console.WriteLine("Q - Quit");

                string userInput = HelperCLI.GetString("Choose One: > ");

                switch (userInput.ToLower())
                {
                    case "1":
                        break;

                    case "2":
                        return;

                    case "q":
                        isExit = true;
                        break;

                    default:
                        break;
                }
            }
        }

        private void DisplayModLists()
        {
            IDictionary<string, ModList> modLists = this.modListDAO.GetAppLists();
            ModList activeList = this.modListDAO.GetGameList();
            string tableHead = "\tModLists\n\r";

            StringBuilder consoleTable = new StringBuilder(tableHead);
            consoleTable.AppendLine("   ".PadRight(Console.WindowWidth - 6, '-'));
            foreach (KeyValuePair<string, ModList> kvp in modLists)
            {
                string key = kvp.Key;
                   
            }
            Console.WriteLine(consoleTable);
            //throw new NotImplementedException();
        }
    }
}