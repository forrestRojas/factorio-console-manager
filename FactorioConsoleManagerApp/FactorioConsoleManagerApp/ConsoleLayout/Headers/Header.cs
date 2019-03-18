using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using FactorioConsoleManagerApp.ConsoleLayout;
using FactorioConsoleManagerApp.ConsoleLayout.Models;

namespace FactorioConsoleManagerApp.ConsoleLayout.Headers
{
    public class Header
    {
        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        public string HeaderText { get; set; }

        /// <summary>
        /// Gets or sets the header box Width (in Chars).
        /// </summary>

        public BoxBuilder BoxBuilder { get; private set; }

        public Box Box { get; private set; }

        public ConsoleColor ForgroundColor { get; set; }

        public ConsoleColor BackgroundColor { get; set; }


        public Header()
        {
            this.Box = new Box();
            this.BoxBuilder = new BoxBuilder();
            this.ForgroundColor = this.Box.ForgroundColor;
            this.BackgroundColor = this.Box.BackgroundColor;
        }


        public void Title(Box box)
        {
            this.Title(box.Message, box.BoxWidth, box.BoxHeight, box.BoxType);
        }

        public void Title(string message, int boxWidth, int boxHeight, string boxType)
        {
            const int sizeAdjust = 1;

            int windowWidth = Console.WindowWidth;
            int bufferWidth = Console.BufferWidth;
            int titleWidth = boxWidth + sizeAdjust;


            //ConsoleColor bgcolor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color)

            // Set window size if dimentions arent correct
            if ((windowWidth != titleWidth) || (bufferWidth != titleWidth))
            {
                Console.SetWindowSize(titleWidth, Console.WindowHeight);
                Console.SetBufferSize(titleWidth, Console.BufferHeight);
            }

            Console.Clear();
            // Set Color
            Console.ForegroundColor = this.ForgroundColor;
            Console.BackgroundColor = this.BackgroundColor;

            // Box Builder;
            string title = this.BoxBuilder.Build(message, boxWidth, boxHeight, boxType);

            // Write to console
            Console.WriteLine(title);
            Console.ResetColor();
        }


        public static string PadSides(string str, int totalWidth, char paddingChar = ' ')
        {
            int padding = totalWidth - str.Length;
            int padLeft = padding / 2 + str.Length;
            return str.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }
    }
}
