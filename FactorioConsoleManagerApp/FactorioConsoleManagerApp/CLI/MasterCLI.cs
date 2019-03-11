using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    public abstract class MasterCLI
    {
        protected const int successCode = 0;

        /// <summary>
        /// Runs the CLI
        /// </summary>
        public abstract void Run();
    }
}