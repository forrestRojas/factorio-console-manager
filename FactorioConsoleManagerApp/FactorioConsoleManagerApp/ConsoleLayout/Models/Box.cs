using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FactorioConsoleManagerApp.ConsoleLayout.Models
{
    /// <summary>
    /// Represents a Box.
    /// </summary>
    public class Box
    {
        public int BoxWidth { get; set; }

        public int BoxHeight { get; set; }

        public string BoxType { get; set; }

        public string Message { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForgroundColor { get; set; }

        public Box()
        {
            this.ForgroundColor = ConsoleColor.White;
            this.BackgroundColor = ConsoleColor.DarkBlue;
        }
    }
}
