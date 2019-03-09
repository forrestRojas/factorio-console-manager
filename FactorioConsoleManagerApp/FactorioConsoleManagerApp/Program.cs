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
            IDictionary<string, JObject> config = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(File.ReadAllText("appsettings.json"));
            //Console.WriteLine(config["gamedata"]["paths"]["dirs"]["mods"]);
            MainMenuCLI mainMenu = new MainMenuCLI();
            mainMenu.Run();

        }
    }
}
