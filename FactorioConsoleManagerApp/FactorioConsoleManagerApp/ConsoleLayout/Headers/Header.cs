using System;
using System.Collections.Generic;
using System.Text;
using FactorioConsoleManagerApp.ConsoleLayout;

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

        public string Color;


        public static void Title(string message, int boxWidth, int boxHeight, string boxType, string color)
        {
            const int sizeAdjust = 1;
            string bgcolor = color;


            Console.Clear();
            // Set window size
            Console.SetWindowSize(boxWidth + sizeAdjust, Console.WindowHeight);
            Console.SetBufferSize(boxWidth + sizeAdjust, Console.BufferHeight);
            // Set Color
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            
            // Box Builder
            BoxBuilder boxBuilder = new BoxBuilder();
            string title = boxBuilder.Build(message, boxWidth, boxHeight, boxType);

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
