using System;
using System.Collections.Generic;
using System.Text;
using FactorioConsoleManagerApp.Models;

namespace FactorioConsoleManagerApp.DAL
{
    public class ModDAO : IModDAO
    {
        private readonly string filepath;

        public ModDAO(string filepath)
        {
            this.filepath = filepath;
        }

        public Mod GetModData()
        {
            throw new NotImplementedException();
        }

        public void SaveModData()
        {
            throw new NotImplementedException();
        }
    }
}
