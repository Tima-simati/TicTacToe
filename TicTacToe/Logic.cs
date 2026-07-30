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
        public static int gameProgressTracker()
        {
            throw new NotImplementedException();
        }
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
