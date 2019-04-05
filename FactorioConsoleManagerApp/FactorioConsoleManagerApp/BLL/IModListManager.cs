using FactorioConsoleManagerApp.DAL;
using FactorioConsoleManagerApp.Models;
using System.Collections.Generic;

namespace FactorioConsoleManagerApp.BLL
{
    public interface IModListManager
    {
        IDictionary<string, ModList> AppLists { get; }

        ModList GameList { get; }
    }
}