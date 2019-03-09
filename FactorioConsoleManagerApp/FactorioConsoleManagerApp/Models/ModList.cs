using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.Models
{
    public class ModList
    {
        public string Name { get; set; }

        public IDictionary<string, ModListItem> ModListItems { get; set; }
    }
}
