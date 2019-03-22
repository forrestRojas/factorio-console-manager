using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    /// <summary>
    /// Represents an IModDAO interface.
    /// </summary>
    public interface IModDAO
    {
        /// <summary>
        /// Gets the Mod pakage data files.
        /// </summary>
        /// <returns></returns>
        Mod GetModData();

        /// <summary>
        /// saves the Mod data files.
        /// </summary>
        void SaveModData();
    }
}
