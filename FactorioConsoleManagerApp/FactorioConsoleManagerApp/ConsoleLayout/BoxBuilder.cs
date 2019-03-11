using System;
using System.Collections.Generic;
//using System.Linq;

namespace FactorioConsoleManagerApp.ConsoleLayout
{
    public class BoxBuilder
    {
        private static Dictionary<string, char[]> BoxTypes
        {
            get
            {
                return new Dictionary<string, char[]>
                {
                    {"light", new char[] { '┌', '┐', '└', '┘', '─', '│' } },
                    {"heavy", new char[] { '┏', '┓', '┗', '┛', '━', '┃' } },
                    {"double", new char[] { '╔', '╗', '╚', '╝', '═', '║' } },
                    {"round", new char[] { '╭', '╮', '╰', '╯', '─', '│' } }
                };
            }
        }

        public BoxBuilder()
        {
        }

        public string[] Build(string message, int boxWidth, int boxHeight, string boxType)
        {
            const int topLeft = 0;
            const int topRight = 1;
            const int bottomLeft = 2;
            const int bottomRight = 3;
            const int horizontal = 4;
            const int vertical = 5;

            int bottomHorizontal = 6;
            int rightVertical = 7;

            char[] boxChars = BoxTypes[boxType.ToLower()];

            if (boxChars.GetUpperBound(0) < bottomHorizontal)
            {
                bottomHorizontal = horizontal;
            }
            if (boxChars.GetUpperBound(0) < rightVertical)
            {
                rightVertical = vertical;
            }

            // TODO Pull these components out into a model
            // Builds the component strings for each line 
            string topBox = boxChars[topLeft] + PadSides("", boxWidth, boxChars[horizontal]) + boxChars[topRight];
            string midBox = boxChars[vertical] + PadSides("", boxWidth) + boxChars[rightVertical];
            string midText = boxChars[vertical] + PadSides(message, boxWidth) + boxChars[rightVertical];
            string bottomBox = boxChars[bottomLeft] + PadSides("", boxWidth, boxChars[bottomHorizontal]) + boxChars[bottomRight];

            // Template for the assembler to create a box with
            string[] boxTemplete = new string[4] { topBox, midBox, midText, bottomBox };

            string[] boxAssembly = BuildBoxAssembly(boxHeight, boxTemplete);

            return boxAssembly;
        }

        private static string[] BuildBoxAssembly(int boxHeight, string[] boxTemplete)
        {
            // top       // top      // top      // top      // top
            // mid       // mid      // mid      // text     // bottom
            // mid       // text     // text     // bottom
            // text      // mid      // bottom
            // mid       // bottom
            // bottom

            const int topbox = 0;
            const int midbox = 1;
            const int midtext = 2;
            const int bottombox = 3;

            // RUN a Loop to build the box
            bool isTextAdded = false;
            bool isText = false;
            List<string> boxAssembly = new List<string>();
            boxAssembly.Add(boxTemplete[topbox]);
            for (int i = 0; i < boxHeight - 2; i++)
            {
                isText = (i + 1) > ((boxHeight - 2) / 2.0);
                if (isText && !isTextAdded)
                {
                    boxAssembly.Add(boxTemplete[midtext]);
                    isTextAdded = true;
                }
                else
                {
                    boxAssembly.Add(boxTemplete[midbox]);
                }
            }
            boxAssembly.Add(boxTemplete[bottombox]);

            return boxAssembly.ToArray();
        }

        private static string PadSides(string str, int totalWidth, char paddingChar = ' ')
        {
            int padding = totalWidth - str.Length;
            int padLeft = padding / 2 + str.Length;
            return str.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }
    }
}