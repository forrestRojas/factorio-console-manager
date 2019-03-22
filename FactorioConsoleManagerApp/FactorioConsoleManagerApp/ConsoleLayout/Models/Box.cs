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
        /// <summary>
        /// The box width in Chars.
        /// </summary>
        public int BoxWidth { get; set; }

        /// <summary>
        /// The height of box in lines.
        /// </summary>
        public int BoxHeight { get; set; }

        /// <summary>
        /// The boxtype
        /// </summary>
        public string BoxType { get; set; }

        /// <summary>
        /// The message the box displays.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The backgroung color of the box.
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// The forground color of the box.
        /// </summary>
        public ConsoleColor ForgroundColor { get; set; }

        /// <summary>
        /// Creates a new Box.
        /// </summary>
        public Box()
        {
            this.BoxWidth = 0;
            this.BoxHeight = 0;
            this.BoxType = "none";
            this.Message = string.Empty;
            this.BackgroundColor = ConsoleColor.DarkBlue;
            this.ForgroundColor = ConsoleColor.White;
        }
    }
}
