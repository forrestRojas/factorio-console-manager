using FactorioConsoleManagerApp.BLL;
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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //TODO Seperate list functonallity from CLI
        private readonly IModListManager modListManager;


        public ModListCLI(IModListManager modListManager)
        {
            this.modListManager = modListManager;
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
            string tableHead = "\tModLists\n\r";

            StringBuilder consoleTable = new StringBuilder(tableHead);
            consoleTable.AppendLine("    ".PadRight(40, '-'));
            consoleTable.AppendLine("\tMODLIST NAME - NUMBER OF MODS");
            consoleTable.AppendLine();
            foreach (KeyValuePair<string, ModList> kvp in this.modListManager.AppLists)
            {
                string key = kvp.Key;
                ModList list = kvp.Value;
                consoleTable.Append('\t');
                consoleTable.Append(list.Name.PadRight(20, '.'));    
                consoleTable.AppendLine(list.ModListItems.Count.ToString());
            }
            Console.WriteLine(consoleTable);
        }
    }
}