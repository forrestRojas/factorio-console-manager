using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    public class ModListDAO :IModListDAO
    {
        private readonly string filepath;

        private class Root
        {
            public List<ModListItem> Mods { get; set; }
        }

        public ModListDAO(string filepath)
        {
            this.filepath = filepath;
        }

        public IDictionary<string, ModList> GetAllModLists()
        {
            SortedDictionary<string, ModList>
        }

        public void SaveAllModLists()
        {
            throw new NotImplementedException();
        }
    }
}
