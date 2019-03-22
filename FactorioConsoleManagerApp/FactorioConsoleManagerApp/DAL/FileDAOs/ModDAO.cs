using System;
using System.Collections.Generic;
using System.Text;
using FactorioConsoleManagerApp.Models;

namespace FactorioConsoleManagerApp.DAL
{
    /// <summary>
    /// Represents a Factorio ModDAO.
    /// </summary>
    public class ModDAO : IModDAO
    {
        /// <summary>
        /// The Mod's file path.
        /// </summary>
        private readonly string filepath;

        /// <summary>
        /// Creates a ModDAO.
        /// </summary>
        /// <param name="filepath">The Mod's file path.</param>
        public ModDAO(string filepath)
        {
            this.filepath = filepath;
        }

        /// <summary>
        /// Gets the Mod Data.
        /// </summary>
        /// <returns>A <see cref="Mod"/> object.</returns>
        public Mod GetModData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the Mod data.
        /// </summary>
        public void SaveModData()
        {
            throw new NotImplementedException();
        }
    }
}
