using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.Models
{
    public class ModList
    {
        /// <summary>
        /// Gets the schema for the mod List model.
        /// </summary>
        [JsonIgnore]
        public JSchema schema { get; }

        public string Name { get; set; }

        public IDictionary<string, ModListItem> ModListItems { get; set; }
    }
}
