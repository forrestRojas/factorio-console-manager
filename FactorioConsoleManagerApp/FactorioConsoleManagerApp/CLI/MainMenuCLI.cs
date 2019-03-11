using FactorioConsoleManagerApp.ConsoleLayout.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    public class MainMenuCLI : MasterCLI
    {
        private const int titleWidth = 50;
        private const int titleHeight = 5;


        public override void Run()
        {
            while (true)
            {
                Console.Clear();
                Header.Title("Welcome to the Factorio Console Manager!", titleWidth, titleHeight, "double", "blue");
                Console.WriteLine();
                Console.WriteLine("1 - Mod Manager");
                Console.WriteLine("2 - Ratio Calculator");
                Console.WriteLine("Q - Quit");

                string userInput = HelperCLI.GetString("Choose One: > ");

                switch (userInput.ToLower())
                {
                    case "1":
                        new ModMangerCLI().Run();
                        break;

                    case "2":
                        new RatioCalculatorCLI().Run();
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
