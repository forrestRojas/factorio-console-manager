using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    public interface IModListDAO
    {
        /// <summary>
        /// Gets a IDictionary of ModLists.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, ModList> GetModListsFormApp();

        /// <summary>
        /// Gets the ModList from the game.
        /// </summary>
        /// <returns></returns>
        ModList GetModListFormGame();

        /// <summary>
        /// Saves the ModLists to the app
        /// </summary>
        /// <param name="modLists"></param>
        void SaveModLists(IDictionary<string, ModList> modLists);

        /// <summary>
        /// Saves the Mod List to the game.
        /// </summary>
        /// <param name="modList"></param>
        void WirteModListToGameModsFolder(ModList modList);
    }
}
