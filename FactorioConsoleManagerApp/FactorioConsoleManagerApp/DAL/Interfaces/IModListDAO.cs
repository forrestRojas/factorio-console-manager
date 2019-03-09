﻿using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.DAL
{
    public interface IModListDAO
    {
        IDictionary<string, ModList> GetAllModLists();

        void SaveAllModLists();
    }
}