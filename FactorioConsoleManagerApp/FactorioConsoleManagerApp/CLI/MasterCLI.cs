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
        /// <summary>
        /// An Exit code that indicates a successful exit.
        /// </summary>
        protected const int successCode = 0;

        /// <summary>
        /// Runs the CLI
        /// </summary>
        public abstract void Run();
    }
}