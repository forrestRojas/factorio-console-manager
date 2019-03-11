using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.ConsoleLayout
{
    public class BoxBuilder
    {
        private Dictionary<string, char[]> boxTypes = new Dictionary<string, char[]>
        {
            {"light", new char[] { '┌', '┐', '└', '┘', '─', '│' } },
            {"heavy", new char[] { '┏', '┓', '┗', '┛', '━', '┃' } },
            {"double", new char[] { '╔', '╗', '╚', '╝', '═', '║' } },
            {"round", new char[] { '╭', '╮', '╰', '╯', '─', '│', } }
        };

        ///// <summary>
        ///// Creates a box using a the standerd light boreder.
        ///// </summary>
        ///// <param name="boxWidth"></param>
        ///// <param name="boxHeight"></param>
        //public BoxBuilder(int boxWidth, int boxHeight)
        //{
        //    this.boxWidth = boxWidth;
        //    this.boxHeight = boxHeight;
        //    this.boxType = "light";
        //}

        ///// <summary>
        ///// Creates a box using a defined boxType from the dictionary.
        ///// </summary>
        ///// <param name="boxWidth">The width of the box in chars.</param>
        ///// <param name="boxHeight">The height of the box in lines.</param>
        ///// <param name="boxType">The defined boxType.</param>
        //public BoxBuilder(int boxWidth, int boxHeight, string boxType)
        //{
        //    this.boxWidth = boxWidth;
        //    this.boxHeight = boxHeight;
        //    this.boxType = boxType.ToLower();
        //}

        /// <summary>
        /// Adds to the boxbuilder dictionary.
        /// An array bigger then 6 chars will modify the right then the bottom boreders.
        /// </summary>
        /// <param name="boxType">the name of the box type</param>
        /// <param name="boxChars">the chars used for the box. {'topright','topleft', 'bottomright', bottomleft, 'left/right', 'top/bottom'}</param>
        public void AddBoxType(string boxType, char[] boxChars)
        {
            if (boxChars.Length < 6)
            {
                throw new ArgumentException(string.Format("Array length: {0} is not greater than or equal to 6", boxChars.Length), "boxChars");
            }
            if (boxChars.Length > 8)
            {
                throw new ArgumentException(string.Format("Array length: {0} is not less than or equal to 8", boxChars.Length), "boxChars");
            }
            this.boxTypes.Add(boxType, boxChars);
        }

        //string topBox = '╔' + PadSides("", boxWidth, '═') + '╗';
        //string midBox = '║' + PadSides("", boxWidth) + '║';
        //string midText = '║' + PadSides(title, boxWidth) + '║';
        //string bottomBox = '╚' + PadSides("", boxWidth, '═') + '╝';
        //string[] boxbulider = new string[] { topBox, midBox, midText, midBox, bottomBox };

        //public 


        public static string PadSides(string str, int totalWidth, char paddingChar = ' ')
        {
            int padding = totalWidth - str.Length;
            int padLeft = padding / 2 + str.Length;
            return str.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }
    }
}

/*
 *  
public static readonly char[][] boxDrawingChars =
{
    new char[] { '─', '━', '│', '┃', '┄', '┅', '┆', '┇', '┈', '┉', '┊', '┋', '┌', '┍', '┎', '┏', },
    new char[] { '┐', '┑', '┒', '┓', '└', '┕', '┖', '┗', '┘', '┙', '┚', '┛', '├', '┝', '┞', '┟', },
    new char[] { '┠', '┡', '┢', '┣', '┤', '┥', '┦', '┧', '┨', '┩', '┪', '┫', '┬', '┭', '┮', '┯', },
    new char[] { '┰', '┱', '┲', '┳', '┴', '┵', '┶', '┷', '┸', '┹', '┺', '┻', '┼', '┽', '┾', '┿', },
    new char[] { '╀', '╁', '╂', '╃', '╄', '╅', '╆', '╇', '╈', '╉', '╊', '╋', '╌', '╍', '╎', '╏', },
    new char[] { '═', '║', '╒', '╓', '╔', '╕', '╖', '╗', '╘', '╙', '╚', '╛', '╜', '╝', '╞', '╟', },
    new char[] { '╠', '╡', '╢', '╣', '╤', '╥', '╦', '╧', '╨', '╩', '╪', '╫', '╬', '╭', '╮', '╯', },
    new char[] { '╰', '╱', '╲', '╳', '╴', '╵', '╶', '╷', '╸', '╹', '╺', '╻', '╼', '╽', '╾', '╿', }
};

public static readonly char[][] blockElements =
{
    new char[] { '▀', '▁', '▂', '▃', '▄', '▅', '▆', '▇', '█', '▉', '▊', '▋', '▌', '▍', '▎', '▏' },

    new char[] { '▐', '░', '▒', '▓', '▔', '▕', '▖', '▗', '▘', '▙', '▚', '▛', '▜', '▝',	 '▞', '▟' }
};
*
*/
