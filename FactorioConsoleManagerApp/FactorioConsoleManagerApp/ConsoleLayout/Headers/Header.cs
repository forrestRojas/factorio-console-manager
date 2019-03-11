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
            const int spacing = 3;
            string bgcolor = color;
            // Box Builder
            BoxBuilder boxBuilder = new BoxBuilder();
            string[] boxAssembly = boxBuilder.Build(message, boxWidth, boxHeight, boxType);

            Console.Clear();
            // Set window size
            Console.SetWindowSize(boxWidth + spacing, Console.WindowHeight);
            Console.SetBufferSize(boxWidth + spacing, Console.BufferHeight);
            // Set Color
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            // Write to console
            WriteHeaderToConsole(boxAssembly);
            Console.ResetColor();
        }

        private static void WriteHeaderToConsole(string[] boxAssembly)
        {
            StringBuilder box = new StringBuilder().AppendJoin('\n', boxAssembly);
            Console.WriteLine(box);
        }

        public static string PadSides(string str, int totalWidth, char paddingChar = ' ')
        {
            int padding = totalWidth - str.Length;
            int padLeft = padding / 2 + str.Length;
            return str.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }
    }
}
