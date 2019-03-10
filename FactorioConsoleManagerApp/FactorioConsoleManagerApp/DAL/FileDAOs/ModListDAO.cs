using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    public class ModListDAO :IModListDAO
    {
        private readonly string appdataFilePath;

        private readonly string gamedataFilePath;

        private class Root
        {
            public List<ModListItem> Mods { get; set; }
        }

        public ModListDAO(string appdataFilePath, string gamedataFilePath)
        {
            this.appdataFilePath = appdataFilePath;
            this.gamedataFilePath = gamedataFilePath;
        }

        /// <summary>
        /// Gets the mod lists from the 
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, ModList> GetModLists()
        {
            SortedDictionary<string, ModList>
        }

        public void SaveModLists()
        {
            throw new NotImplementedException();
        }
    }
}
