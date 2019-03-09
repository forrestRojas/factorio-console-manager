using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    public interface IModListItemDAO
    {
        IDictionary<string, ModListItem> GetModList();

        void SaveModList();
    }
}
