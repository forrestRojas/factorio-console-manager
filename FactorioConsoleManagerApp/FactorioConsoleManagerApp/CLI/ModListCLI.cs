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
        private const int titleWidth = 50;
        private const int titleHeight = 5;

        private readonly IModListDAO modListDAO;

        public ModListCLI()
        {
            this.modListDAO = new ModListJsonDAO("C:/Users/Forrest Rojas/AppData/Roaming/Factorio/mods/mod-list.json", "C:/Users/Forrest Rojas/AppData/Roaming/Factorio/mods/mod-list.json");
        }

        /// <summary>
        /// Runs the ModListCLI
        /// </summary>
        public override void Run()
        {

            while (true)
            {
                Console.Clear();
                new Header().Title("Mod Lists", titleWidth, titleHeight, "double");
                Console.WriteLine();
                // Display modlist and active list
                Console.WriteLine("1 - Choose a list");
                Console.WriteLine("2 - Go Back To Mod Manger Menu");
                Console.WriteLine("Q - Quit");

                string userInput = HelperCLI.GetString("Choose One: > ");

                switch (userInput.ToLower())
                {
                    case "1":
                        break;

                    case "2":
                        break;

                    case "q":
                        Environment.Exit(successCode);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}