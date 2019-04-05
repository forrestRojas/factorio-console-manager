using FactorioConsoleManagerApp.DAL;
using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.BLL
{
    public class ModListManager : IModListManager
    {
        private readonly IModListDAO modListDAO;

        public IDictionary<string, ModList> AppLists { get; private set; }

        public ModList GameList { get; private set; }

        public ModListManager()
        {
        }

        public ModListManager(IModListDAO modListDAO)
        {
            this.modListDAO = modListDAO;
            SetListFromDAO();
        }

        /// <summary>
        /// Sets the lists at instantiation.
        /// </summary>
        private void SetListFromDAO()
        {
            this.AppLists = this.modListDAO.GetAppLists();
            this.GameList = this.modListDAO.GetGameList();
        }
    }
}
