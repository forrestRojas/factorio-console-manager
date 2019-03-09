using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.Models
{
    public class ModListItem
    {   
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
