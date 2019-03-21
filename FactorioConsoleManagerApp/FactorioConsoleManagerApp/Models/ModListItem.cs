using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.Models
{
    /// <summary>
    /// Represents a ModList Item
    /// </summary>
    public class ModListItem
    {   
        /// <summary>
        /// Gets the schema for the mod List item model.
        /// </summary>
        [JsonIgnore]
        public JSchema Schema { get; }

        /// <summary>
        /// The mod data for the item.
        /// </summary>
        [JsonIgnore]
        public Mod Mod { get; set; }

        /// <summary>
        /// Gets or Sets the name of the ist item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates wheater or not the mod is enabled.
        /// </summary>
        public bool Enabled { get; set; }
    }
}
