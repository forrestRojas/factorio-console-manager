using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    /// <summary>
    /// Reprsents an interface for the ModListDAO.
    /// </summary>
    public interface IModListDAO
    {
        /// <summary>
        /// Gets a IDictionary of ModLists.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> of Modlists</returns>
        IDictionary<string, ModList> GetAppLists();

        /// <summary>
        /// Gets the ModList from the game.
        /// </summary>
        /// <returns>A <see cref="ModList"/>.</returns>
        ModList GetGameList();

        /// <summary>
        /// Saves the ModLists to the app
        /// </summary>
        /// <param name="modLists">The <see cref="IDictionary{TKey, TValue}"/> of Modlists</param>
        void SaveModLists(IDictionary<string, ModList> modLists);

        /// <summary>
        /// Saves the Mod List to the game.
        /// </summary>
        /// <param name="modList">A <see cref="ModList"/>.</param>
        void WriteListToGame(ModList modList);
    }
}
