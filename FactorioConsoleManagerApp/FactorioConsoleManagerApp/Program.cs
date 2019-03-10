using System;
using Newtonsoft.Json;
using FactorioConsoleManagerApp.CLI;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FactorioConsoleManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
   
            MainMenuCLI mainMenu = new MainMenuCLI();
            mainMenu.Run();

        }
    }
}
