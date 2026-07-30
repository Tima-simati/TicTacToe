using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Pastel;

namespace TicTacToe
{
    static public class Logic
    {
        public static int rows = 3, columns = 3;
        public static string[,] gameField = new string[rows, columns];
        public static string[,] testfield = new string[3, 3] { { "X", " ", "O" }, { "X", " ", "O" }, { "X", " ", "O" } };

        //initialization of fresh game field
        public static void newGameField()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = " ".PadLeft(2).PadRight(3);
                }
            }
        }
        //build an AI that also places their symbol
        public static void playDecisionMakerAI()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = "X";
                }
            }
        }
        //check when the game is over
        public static void gameProgressTracker()
        {
            
        }

        /// <summary>
        /// Support Method to put the Text in center with paddig
        /// </summary>
        /// <param name="text">this is the character, string, which needs to be put in center</param>
        /// <param name="width">the width of extra added space</param>
        /// <returns>a new string with the text and padding with spaces to the left and right is added</returns>
        public static string CenterText(string text, int width)
        {           
            if (text.Length >= width)
            {
                return text;
            }
            int totalPadding = width - text.Length;
            int padLeft = totalPadding / 2;
            int padRight = totalPadding - padLeft;

            return new string(' ', padLeft) + text + new string(' ', padRight);
        }

    }
}
