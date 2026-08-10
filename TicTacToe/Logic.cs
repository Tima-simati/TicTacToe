using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToe
{
    static public class Logic
    {
        public const int ROWS = 3, COLUMNS = 3; //indices of gameField
        public const int LAST_INDEX_GRID = ROWS - 1;
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
            //check for 2 same symbols in horizontal lines and insert third symbol there
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (CheckIfSlotIsEmpty(field, i, j) && CheckHorizontalLineForAI(field, i, j))
                    {
                        field[i, j] = symbolAI;
                        return field;
                    }
                }
            }
            //check for 2 same symbols in vertical lines and insert third symbol there
            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    if (CheckIfSlotIsEmpty(field, j, i) && CheckVerticalLineForAI(field, j, i))
                    {
                        field[j, i] = symbolAI;
                        return field;
                    }
                }
            }
            //check for 2 same symbols in diagonal lines and insert third symbol there
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (CheckIfSlotIsEmpty(field, i, j) && CheckDiagonalLineForAI(field, i, j))
                    {
                        field[i, j] = symbolAI;
                        return field;
                    }
                }
            }
            //not 2 same symbols found; find random new empty spot
            do
            {
                randomRowIndex = rng.Next(LOWERBOUND_INDEX, UPPERBOUND_INDEX);
                randomColumnIndex = rng.Next(LOWERBOUND_INDEX, UPPERBOUND_INDEX);
            } while (!CheckIfSlotIsEmpty(field, randomRowIndex, randomColumnIndex));
            field[randomRowIndex, randomColumnIndex] = symbolAI;
            return field;
        }
        //for horizontal line check: checks left spot to the current spot
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
        //for horizontal line check: checks right spot to the current spot
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
        //for vertical line check: checks spot above the current spot
        public static bool CheckUpperSpotOfIndex(string[,] array, int row, int col)
        {
            if (row == 0)
            {
                row = array.GetLength(0);
            }
            if (array[--row, col] == "X")
            {
                return true;
            }
            return false;
        }
        //for vertical line check: check spot above the current spot
        public static bool CheckLowerSpotOfIndex(string[,] array, int row, int col)
        {
            if (row == array.GetLength(0) - 1)
            {
                row = -1;
            }
            if (array[++row, col] == "X")
            {
                return true;
            }
            return false;
        }
        public static bool CheckDecliningDiagonalPreviousSpot(string[,] array, int row, int col)
        {
            if (row == 0 && col == 0)
            {
                row = array.GetLength(0);
                col = array.GetLength(1);
            }
            if (array[--row, --col] == "X")
            {
                return true;
            }
            return false;
        }
        public static bool CheckDecliningDiagonalNextSpot(string[,] array, int row, int col)
        {
            if (row == array.GetLength(0) - 1 && col == array.GetLength(1) - 1)
            {
                row = -1;
                col = -1;
            }
            if (array[++row, ++col] == "X")
            {
                return true;
            }
            return false;
        }
        public static bool CheckIncliningDiagonalPreviousSpot(string[,] array, int row, int col)
        {
            if (row == array.GetLength(0) - 1 && col == 0)
            {
                row = -1;
                col = array.GetLength(1);
            }
            if (array[++row, --col] == "X")
            {
                return true;
            }
            return false;
        }
        public static bool CheckIncliningDiagonalNextSpot(string[,] array, int row, int col)
        {
            if (row == 0 && col == array.GetLength(1) - 1)
            {
                row = array.GetLength(0);
                col = -1;
            }
            if (array[--row, ++col] == "X")
            {
                return true;
            }
            return false;
        }
        //checks if spot has no symbol entry
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
        //check if left and right spot to the current index have player symbol
        public static bool CheckHorizontalLineForAI(string[,] field, int row, int col)
        {
            if (CheckLeftSpotOfIndex(field, row, col) && CheckRightSpotOfIndex(field, row, col))
            {
                return true;
            }
            return false;
        }
        //check if upper and lower spot to the current index have player symbol
        public static bool CheckVerticalLineForAI(string[,] field, int row, int col)
        {
            if (CheckLowerSpotOfIndex(field, row, col) && CheckUpperSpotOfIndex(field, row, col))
            {
                return true;
            }
            return false;
        }

        //check if diagonal previous spot and next spot to the current index have the player symbol as entry
        public static bool CheckDiagonalLineForAI(string[,] field, int row, int col)
        {
            if (row == col)
            {
                if (CheckDecliningDiagonalPreviousSpot(field, row, col) && CheckDecliningDiagonalNextSpot(field, row, col))
                {
                    return true;
                }
            }
            if (row + col == field.GetLength(0)-1)
            {
                if (CheckIncliningDiagonalPreviousSpot(field, row, col) && CheckIncliningDiagonalNextSpot(field, row, col))
                {
                    return true;
                }
            }           
            return false;
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
