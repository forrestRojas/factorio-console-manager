using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.Models
{
    public class Mod
    {
        /// <summary>
        /// Gets or sets the Name of the mod.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Verson of the mod.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the game version the mod is for.
        /// </summary>
        public string FactorioVersion { get; set; }

        /// <summary>
        /// Gets or sets the title of the mod.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Home page of the mod on the factorio forums.
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// Get or sets mod description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the dependencies of the mod.
        /// </summary>
        public List<string> Dependencies { get; set; }
    }
}
