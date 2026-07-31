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
        public const int CENTER_INDEX = 1;
        public static int inputOfAI = 0;
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
            //first move to place "O" in the center, only if field is free
            if (Program.turnCounter == 2 && gameField[CENTER_INDEX, CENTER_INDEX] == " ")
            {
                gameField[CENTER_INDEX, CENTER_INDEX] = "O";
            }
            if (horizontalLineCheckAI() != 0)
            {
                inputOfAI = horizontalLineCheckAI();
            }
            if (verticalLineCheckAI() != 0)
            {
                inputOfAI = horizontalLineCheckAI();
            }
            if (diagonalLineCheckAI() != 0)
            {
                inputOfAI = diagonalLineCheckAI();
            }
            else //if conditions above not apply for next move, then choose next available field;  maybe put a rng to placement of first symbol
            {
                for (int i = 0; i < ROWS; i++)
                {
                    for (int j = 0; j < COLUMNS; j++)
                    {
                        if (gameField[i, j] == " ")
                        {
                            gameField[i, j] = "O";
                        }
                    }
                }
            }
        }
        /// <summary>
        /// turn user input or AI input into array coordinates to set player symbol
        /// </summary>
        /// <param name="positionSet">input of numbers from 1 to 9 according to the 9 fields</param>
        public static void insertInputInArray(int positionSet)
        {
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
            if (Program.turnCounter % 2 == 1)
            {
                gameField[row_index, column_index] = "X"; //user symbol
            }
            else
            {
                gameField[row_index, column_index] = "O"; //AI symbol
            }
        }

        /*checks to prevent AI lose or AI wins*/
        /// <summary>
        /// checks horizontal lines for 2 player symbols about to win and prevent it or 2 AI symbols in a line and go for a win;
        /// </summary>
        /// <returns>position of AI next move</returns>
        public static int horizontalLineCheckAI()
        {
            int symbolCounter = 0;
            int positionMoveAI = 0;

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (gameField[i, j] == gameField[i, j + 1])
                    {
                        symbolCounter++;
                    }
                    if (symbolCounter == 2)
                    {
                        positionMoveAI = i * 3 + j;
                    }
                }
            }
            return positionMoveAI; //outputs AI next move
        }
        /// <summary>
        /// checks vertical lines for 2 player symbols about to win and prevent it or 2 AI symbols in a line and go for a win;
        /// </summary>
        /// <returns>position of AI next move</returns>
        public static int verticalLineCheckAI()
        {
            int symbolCounter = 0;
            int positionMoveAI = 0;

            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (gameField[j, i] == gameField[j, i + 1])
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
        public static int diagonalLineCheckAI()
        {
            int symbolCounter = 0;
            int positionMoveAI = 0;
            for (int i = 0, j = 0; i < LAST_INDEX_GRID; i++, j++)
            {
                if (gameField[i, j] == gameField[i + 1, j + 1])
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
                if (gameField[i, j] == gameField[i - 1, j + 1])
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
