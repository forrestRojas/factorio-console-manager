using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.ConsoleLayout
{
    public class BoxBuilder1
    {

        public string Message { get; }

        /// <summary>
        /// Gets or sets the header box Width (in Chars).
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets or sets the header box Width (in Lines).
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets or sets the box border.
        /// </summary>
        public int Border { get; }

        public string Color { get; set; }

        private readonly string boxType;

        public Dictionary<string, char[]> BoxTypes 
        {
            get 
            {
                Dictionary<string, char[]> boxTypes = new Dictionary<string, char[]>
                {
                    {"light", new char[] { '┌', '┐', '└', '┘', '─', '│' } },
                    {"heavy", new char[] { '┏', '┓', '┗', '┛', '━', '┃' } },
                    {"double", new char[] { '╔', '╗', '╚', '╝', '═', '║' } },
                    {"round", new char[] { '╭', '╮', '╰', '╯', '─', '│', } }
                };

                return boxTypes;
            }
        }
            
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
            this.BoxTypes.Add(boxType, boxChars);
        }

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
