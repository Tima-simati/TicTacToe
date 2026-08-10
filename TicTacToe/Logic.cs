using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Pastel;

namespace TicTacToe
{
    static public class Logic
    {
        public const int ROWS = 3, COLUMNS = 3; //indices of gameField
        public const int LAST_INDEX_GRID = ROWS - 1;
        public const int CENTER_INDEX = 1; //const for putting AI symbol dead center in first round
        public static int inputOfAI = 0;   //symbol placement of AI
        public static string symbolAI = "O";
        //variables to randomly put AI symbol into a field
        const int LOWERBOUND_INDEX = 0;
        const int UPPERBOUND_INDEX = 3;

        public static readonly Random rng = new Random();

        public static int randomRowIndex = 1;
        public static int randomColumnIndex = 1;

        //initialization of fresh game field
        public static string[,] CreateNewGameField(string[,] field)
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    field[i, j] = " ".PadLeft(2).PadRight(3);
                }
            }
            return field;
        }
        //build an AI that also places their symbol
        /// <summary>
        /// method, which decides, where the CPU should place its next symbol
        /// </summary>
        public static string[,] PlayDecisionMakerAI(string[,] field)
        {
            while (CheckIfSlotIsEmpty(field, randomRowIndex, randomColumnIndex) != false)
            {
                randomRowIndex = rng.Next(LOWERBOUND_INDEX, UPPERBOUND_INDEX);
                randomColumnIndex = rng.Next(LOWERBOUND_INDEX, UPPERBOUND_INDEX);
            }
            field[randomRowIndex, randomColumnIndex] = symbolAI;
            return field;
        }
        public static bool CheckLeftSpotOfIndex(string[,] array, int row, int col)
        {
            if (col == 0)
            {
                col = array.GetLength(1);
            }
            if (array[row, --col] == "X")
            {
                return true;
            }
            return false;
        }

        public static bool CheckRightSpotOfIndex(string[,] array, int row, int col)
        {
            if (col == array.GetLength(1) - 1)
            {
                col = -1;
            }
            if (array[row, ++col] == "X")
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfSlotIsEmpty(string[,] array, int row, int col)
        {
            if (array[row, col] == "   ")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// turn user input or AI input into array coordinates to set player symbol
        /// </summary>
        /// <param name="positionSet">input of numbers from 1 to 9 according to the 9 fields</param>

        public static string[,] InsertInputInArray(int positionSet, string[,] field, string symbol)
        {
            int row_index = 0;
            int column_index = 0;
            int indicesOfPosition = positionSet - 1; //aux variable to help with computing column index
            for (int i = 0; i < ROWS; i++)
            {
                if (indicesOfPosition / ROWS == i)
                {
                    row_index = i;
                    break;
                }
            }
            for (int j = 0; j < COLUMNS; j++)
            {
                if (indicesOfPosition % COLUMNS == j)
                {
                    column_index = j;
                    break;
                }
            }

            field[row_index, column_index] = symbol; //symbol
            return field;
        }

        public static bool CheckHorizontalLineForAI(string[,] field)
        {
            if (CheckLeftSpotOfIndex(field, randomRowIndex, randomColumnIndex) && CheckRightSpotOfIndex(field, randomRowIndex, randomColumnIndex))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks vertical lines for 2 player symbols about to win and prevent it or 2 AI symbols in a line and go for a win;
        /// </summary>
        /// <returns>position of AI next move</returns>
        public static int CheckVerticalLineForAI(string[,] field)
        {
            int symbolCounter = 0;
            int positionMoveAI = 0;

            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (field[j, i] == field[j, i + 1])
                    {
                        symbolCounter++;
                    }
                    if (symbolCounter == 2)
                    {
                        positionMoveAI = i + j * 3;
                    }
                }
            }
            return positionMoveAI; //outputs AI next move
        }
        /// <summary>
        /// checks diagonal lines for 2 player symbols about to win and prevent it or 2 AI symbols in a line and go for a win;
        /// </summary>
        /// <returns>position of AI next move</returns>
        public static int CheckDiagonalLineForAI(string[,] field)
        {
            int symbolCounter = 0;
            int positionMoveAI = 0;
            for (int i = 0, j = 0; i < LAST_INDEX_GRID; i++, j++)
            {
                if (field[i, j] == field[i + 1, j + 1])
                {
                    symbolCounter++;
                }
                if (symbolCounter == 2)
                {
                    positionMoveAI = i + j * 3;
                    return positionMoveAI;
                }
            }

            for (int i = LAST_INDEX_GRID, j = 0; i > 0; i--, j++)
            {
                if (field[i, j] == field[i - 1, j + 1])
                {
                    symbolCounter++;
                }
                if (symbolCounter == 2)
                {
                    positionMoveAI = i + j * 3;
                    return positionMoveAI;
                }

            }
            return positionMoveAI; //returns 0, if no 2 matching symbols found
        }

        /*checks when the game is over*/
        public static bool CheckForWin(string[,] field, string symbol)
        {
            bool horizontalStatus = CheckHorizontalLineWin(field, symbol);
            bool verticalStatus = CheckVerticalLineWin(field);
            bool diagonalStatus = CheckDiagnoalLinesWin(field);

            //
            if (horizontalStatus == true || verticalStatus == true || diagonalStatus == true)
            {
                return true;
            }

            return false;
        }

        /*checks when the game is over*/

        /// <summary>
        /// check if any of the 3 horizontal lines have same 3 symbols to win
        /// </summary>
        /// <returns>true for winning match found, false for not found</returns>
        public static bool CheckHorizontalLineWin(string[,] field, string symbol)
        {
            bool allEqual = true;
            for (int i = 0; i < ROWS; i++)
            {
                allEqual = true;
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (field[i, j] != symbol || field[i, j] != field[i, j + 1])
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
        public static bool CheckVerticalLineWin(string[,] field)
        {
            bool allEqual = true;
            for (int i = 0; i < COLUMNS; i++)
            {
                allEqual = true;
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (field[j, i] == "   " || field[j, i] != field[j + 1, i])
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
        public static bool CheckDiagnoalLinesWin(string[,] field)
        {
            bool allEqual = true;
            for (int i = 0, j = 0; i < LAST_INDEX_GRID; i++, j++)
            {
                allEqual = true;
                if (field[i, j] == "   " || field[i, j] != field[i + 1, j + 1])
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual)
            {
                return true;
            }
            allEqual = true;
            for (int i = LAST_INDEX_GRID, j = 0; i > 0; i--, j++)
            {
                allEqual = true;
                if (field[i, j] == "   " || field[i, j] != field[i - 1, j + 1])
                {
                    allEqual = false;
                    break;
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
