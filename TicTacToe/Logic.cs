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
        public static void gameProgressTracker(int positionSet)
        {
            //turn userInput into array coordinates to set player symbol
            int row_index = 0;
            int column_index = 0;
            for (int i = 0; i < rows; i++)
            {
                if (positionSet / rows == i)
                {
                    row_index = i;
                }
            }
            for (int j = 0; j < columns; j++)
            {
                if (positionSet / columns == j)
                {
                    column_index = j;
                }
            }
            gameField[row_index, column_index] = "X"; 

            
        }
    }
}
