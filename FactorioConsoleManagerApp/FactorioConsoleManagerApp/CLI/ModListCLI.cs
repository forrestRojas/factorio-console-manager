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
        /// <summary>
        /// Runs the ModListCLI
        /// </summary>
        public override void Run()
        {
            IModListDAO modListDAO = new ModListJsonDAO("C:/Users/Forrest Rojas/AppData/Roaming/Factorio/mods/mod-list.json", "C:/Users/Forrest Rojas/AppData/Roaming/Factorio/mods/mod-list.json");
            ModList modList = modListDAO.GetModListFormGame();
            Console.WriteLine(modList);
            Console.Read();
        }
    }
}