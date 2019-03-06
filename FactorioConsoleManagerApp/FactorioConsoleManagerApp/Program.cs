using System;
using Newtonsoft.Json;
using FactorioConsoleManagerApp.CLI;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace FactorioConsoleManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic config = JsonConvert.DeserializeObject(File.ReadAllText("appsettings.json"));
            
            Console.WriteLine(config.paths.gamedata.dirs.mods);
        }
    }
}
