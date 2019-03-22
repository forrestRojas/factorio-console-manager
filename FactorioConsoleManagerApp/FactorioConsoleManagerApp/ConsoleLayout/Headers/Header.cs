﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using FactorioConsoleManagerApp.ConsoleLayout;
using FactorioConsoleManagerApp.ConsoleLayout.Models;

namespace FactorioConsoleManagerApp.ConsoleLayout.Headers
{
    public class Header : Box
    {
        /// <summary>
        /// Gets or Sets the Boxbulider.
        /// </summary>
        public BoxBuilder BoxBuilder { get; private set; }


        public Header()
        {
            this.BoxBuilder = new BoxBuilder();
            this.ForgroundColor = this.ForgroundColor;
            this.BackgroundColor = this.BackgroundColor;
        }


        public void Title()
        {
            this.Title(this.Message, this.BoxWidth, this.BoxHeight, this.BoxType);
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
