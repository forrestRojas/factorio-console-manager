using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.Models
{
    /// <summary>
    /// Represents a Factorio Mod List.
    /// </summary>
    public class ModList
    {
        /// <summary>
        /// Gets the schema for the mod List model.
        /// </summary>
        [JsonIgnore]
        public JSchema Schema { get; }

        /// <summary>
        /// The Name of the modlist.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An Idctionary of modlistItems accessed via the mod name.
        /// </summary>
        public IDictionary<string, ModListItem> ModListItems { get; set; }
    }
}
