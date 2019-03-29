using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    /// <summary>
    /// Represents a CLI.
    /// </summary>
    public abstract class MasterCLI
    {
        protected static bool isExit = false;

        public MasterCLI()
        {

        }
        /// <summary>
        /// Runs the CLI
        /// </summary>
        public abstract void Run();
    }
}