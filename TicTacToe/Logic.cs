using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Pastel;

namespace TicTacToe
{
    static public class Logic
    {
        public const int ROWS = 3, COLUMNS = 3;
        public const int LAST_INDEX_GRID = ROWS - 1;
        public static string[,] gameField = new string[ROWS, COLUMNS];
        public static string[,] testfield = new string[3, 3] { { "X", " ", "O" }, { "X", " ", "O" }, { "X", " ", "O" } };

        //initialization of fresh game field
        public static void newGameField()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    gameField[i, j] = " ".PadLeft(2).PadRight(3);
                }
            }
        }
        //build an AI that also places their symbol
        public static void playDecisionMakerAI()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    gameField[i, j] = "X";
                }
            }
        }
        //check when the game is over
        public static void insertUserInputInArray(int positionSet)
        {
            //turn userInput into array coordinates to set player symbol
            int row_index = 0;
            int column_index = 0;
            for (int i = 0; i < ROWS; i++)
            {
                if (positionSet / ROWS == i)
                {
                    row_index = i;
                }
            }
            for (int j = 0; j < COLUMNS; j++)
            {
                if (positionSet / COLUMNS == j)
                {
                    column_index = j;
                }
            }
            gameField[row_index, column_index] = "X";
        }
        /// <summary>
        /// check if any of the 3 horizontal lines have same 3 symbols to win
        /// </summary>
        /// <returns>true for winning match found, false for not found</returns>
        public static bool checkHorizontalLineWin()
        {
            bool allEqual = true;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (gameField[i, j] != gameField[i, j + 1])
                    {
                        allEqual = false;                        
                    }
                }
                if (allEqual)
                {
                    return true;
                }               
            }
            return false;
        }
        /// <summary>
        /// check if any of the 3 vertical lines have same 3 symbols to win
        /// </summary>
        /// <returns>true for winning match found, false for not found</returns>
        public static bool checkVerticalLines()
        {
            bool allEqual = true;
            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (gameField[j, i] != gameField[j + 1, i])
                    {
                        allEqual = false;                        
                    }
                }
                if (allEqual)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// check if any of the 2 diagonal lines have same 3 symbols to win
        /// </summary>
        /// <returns>true for winning match found, false for not found</returns>
        public static bool checkDiagnoalLinesWin()
        {
            bool allEqual = true;
            for (int i = 0, j = 0; i < LAST_INDEX_GRID; i++, j++)
            {
                if (gameField[i, j] != gameField[i + 1, j + 1])
                {
                    allEqual = false;                   
                }
            }
            if (allEqual)
            {
                return true;
            }
            allEqual = true;
            for (int i = LAST_INDEX_GRID, j = 0; i > 0; i--, j++)
            {
                if (gameField[i, j] != gameField[i - 1, j + 1])
                {
                    allEqual = false;                  
                }
            }
            if (allEqual)
            {
                return true;
            }
            return false;
        }
    }
}
