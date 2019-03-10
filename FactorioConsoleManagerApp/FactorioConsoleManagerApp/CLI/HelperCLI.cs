using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.CLI
{
    public static class HelperCLI
    {
        private const int returnToInputLine = 2;

        /// <summary>
        /// This continually prompts the user until they enter a valid string (1 or more characters).
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <returns>The console input as a string.</returns>
        public static string GetString(string message)
        {
            string userInput = string.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= returnToInputLine;
                    ClearLine();
                }
                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (string.IsNullOrEmpty(userInput));

            return userInput;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid integer.
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <param name="lowerLimt">The lower limit. <c>null</c> means no limit.</param>
        /// <param name="upperLimt">The upper limit. <c>null</c> means no limit.</param>
        /// <returns>The console input as a integer.</returns>
        public static int GetInteger(string message, int? lowerLimit = null, int? upperLimit = null)
        {
            string userInput = string.Empty;
            int intValue = 0;
            int numberOfAttempts = 0;
            bool isInt = false;
            bool inRange = true;
            bool hasUpperLimit = upperLimit != null;
            bool hasLowerLimit = lowerLimit != null;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= returnToInputLine;
                    ClearLine();
                }

                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out intValue);
                if (isInt)
                {
                    if (hasLowerLimit)
                    {
                        inRange = intValue > lowerLimit;
                    }
                    if (hasUpperLimit)
                    {
                        inRange = intValue < upperLimit;
                    }
                }

                numberOfAttempts++;
            }
            while (!isInt || !inRange);

            return intValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid double.
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <param name="lowerLimt">The lower limit. <c>null</c> means no limit.</param>
        /// <param name="upperLimt">The upper limit. <c>null</c> means no limit.</param>
        /// <returns>The console input as a double.</returns>
        public static double GetDouble(string message, double? lowerLimit = null, double? upperLimit = null)
        {
            string userInput = string.Empty;
            double doubleValue = 0;
            int numberOfAttempts = 0;
            bool isDouble = false;
            bool inRange = true;
            bool hasUpperLimit = upperLimit != null;
            bool hasLowerLimit = lowerLimit != null;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= returnToInputLine;
                    ClearLine();
                }

                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                isDouble = double.TryParse(userInput, out doubleValue);
                if (isDouble)
                {
                    if (hasLowerLimit)
                    {
                        inRange = doubleValue > lowerLimit;
                    }
                    if (hasUpperLimit)
                    {
                        inRange = doubleValue < upperLimit;
                    }
                }

                numberOfAttempts++;
            }
            while (!isDouble || !inRange);

            return doubleValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid bool.
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <returns>The console input as a bool.</returns>
        public static bool GetBool(string message)
        {
            string userInput = string.Empty;
            bool boolValue = false;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= returnToInputLine;
                    ClearLine();
                }
                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!bool.TryParse(userInput, out boolValue));

            return boolValue;
        }

        /// <summary>
        /// Writes a line relative to the console cursor's current postion, then returns to the original line.
        /// </summary>
        /// <remarks>This methoed expects that you are statring at the last line written to the console.</remarks>
        /// <param name="message">The line to be displayed.</param>
        /// <param name="rowsAway">The number of rows away from the current line (positive goes up, negitive goes down, zero is the current line).</param>
        /// <param name="overwrite">Will overwrite the line if TRUE</param>
        public static void InsertLineRelative(string message, int rowsAway = 0, bool overwrite = false)
        {
            // Remembers the cursor original coordinates
            int initialRow = Console.CursorTop;
            int initialColumn = Console.CursorLeft;
            int insertLine = initialRow - rowsAway;

            // Inserts above the current line
            if (insertLine < 0)
            {
                // prevents the insertLine from going beyond the TOP of the buffer
                insertLine = 0;
            }
            if (rowsAway >= 0 && overwrite) // overwrite 
            {
                Console.SetCursorPosition(0, insertLine);
                ClearLine();
                Console.Write(message);
                Console.SetCursorPosition(initialColumn, initialRow);
            }
            else if (rowsAway >= 0 && !overwrite) // Dont overwrite
            {
                Console.MoveBufferArea(0, insertLine, (Console.BufferWidth - 1), (rowsAway + 1), 0, (insertLine + 1));
                Console.SetCursorPosition(0, insertLine);
                Console.Write(message);
                Console.SetCursorPosition(initialColumn, (initialRow + 1));
            }

            // Inserts below the current line
            if ((rowsAway * -1) >= Console.BufferHeight)
            {
                // prevents the insertLine from going beyond the BOTTOM of the buffer
                rowsAway = Console.BufferHeight - 1;
                insertLine = initialRow - rowsAway;
            }
            if (rowsAway < 0 && overwrite) // overwrite
            {
                Console.SetCursorPosition(0, insertLine);
                ClearLine();
                Console.Write(message);
                Console.SetCursorPosition(initialColumn, initialRow);
            }
            else if (rowsAway < 0 && !overwrite) // Dont overwrite
            {
                Console.SetCursorPosition(0, insertLine);
                Console.MoveBufferArea(0, insertLine, (Console.BufferWidth - 1), (Console.BufferHeight - 1 - insertLine), 0, (insertLine + 1));
                Console.Write(message);
                Console.SetCursorPosition(initialColumn, initialRow);
            }
        }

        /// <summary>
        /// Clears the current Console Line
        /// </summary>
        public static void ClearLine()
        {
            Console.Write(new string(' ', (Console.BufferWidth - Console.CursorLeft)));
            Console.CursorTop--;
        }
    }
}
