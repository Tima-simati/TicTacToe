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


        //initialization of fresh game field
        public static void newGameField()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Program.gameField[i, j] = " ".PadLeft(2).PadRight(3);
                }
            }
        }
        //build an AI that also places their symbol
        /// <summary>
        /// method, which decides, where the CPU should place its next symbol
        /// </summary>
        public static void playDecisionMakerAI()
        {

            //variables to randomly put AI symbol into a field
            const int LOWERBOUND_INDEX = 0;
            const int UPPERBOUND_INDEX = 2;

            Random rng = new Random();
            int randomRow = rng.Next(LOWERBOUND_INDEX, UPPERBOUND_INDEX);
            int randomColumn = rng.Next(LOWERBOUND_INDEX, UPPERBOUND_INDEX);

            //first move to place "O" in the center, only if field is free
            if (Program.turnCounter == 2 && Program.gameField[CENTER_INDEX, CENTER_INDEX] == " ")
            {
                Program.gameField[CENTER_INDEX, CENTER_INDEX] = "O";
                return;

                //first move to place "O" in the center, only if field is free
                if (Program.turnCounter == 2 && Program.gameField[CENTER_INDEX, CENTER_INDEX] == " ")
                {
                    Program.gameField[CENTER_INDEX, CENTER_INDEX] = "O";

                }
                if (horizontalLineCheckAI() != 0)
                {
                    inputOfAI = horizontalLineCheckAI();
                    insertInputInArray(inputOfAI, symbolAI);
                    return;
                }
                if (verticalLineCheckAI() != 0)
                {
                    inputOfAI = horizontalLineCheckAI();
                    insertInputInArray(inputOfAI, symbolAI);
                    return;

                }
                if (diagonalLineCheckAI() != 0)
                {
                    inputOfAI = diagonalLineCheckAI();

                    insertInputInArray(inputOfAI, symbolAI);
                    return;
                }
                if (Program.gameField[randomRow, randomColumn] == " ")
                {
                    Program.gameField[randomRow, randomColumn] = "O";
                    //if AI should input O iteratively in fields, instead of random
                    //for (int i = 0; i < ROWS; i++)
                    //{
                    //    for (int j = 0; j < COLUMNS; j++)
                    //    {
                    //        if (Program.gameField[i, j] == " ")
                    //        {
                    //            Program.gameField[i, j] = "O";
                    //        }
                    //    }
                    //}
                    return;

                }                
            }
        }
        /// <summary>
        /// turn user input or AI input into array coordinates to set player symbol
        /// </summary>
        /// <param name="positionSet">input of numbers from 1 to 9 according to the 9 fields</param>

        public static void insertInputInArray(int positionSet, string symbol)
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

            Program.gameField[row_index, column_index] = symbol; //user symbol

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
                    if (Program.gameField[i, j] == Program.gameField[i, j + 1])
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
                    if (Program.gameField[j, i] == Program.gameField[j, i + 1])
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
                if (Program.gameField[i, j] == Program.gameField[i + 1, j + 1])
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
                if (Program.gameField[i, j] == Program.gameField[i - 1, j + 1])
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
        public static bool checkForWin()
        {
            bool horizontalStatus = checkHorizontalLineWin();
            bool verticalStatus = checkVerticalLineWin();
            bool diagonalStatus = checkDiagnoalLinesWin();

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
        public static bool checkHorizontalLineWin()
        {
            bool allEqual = true;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (Program.gameField[i, j] != Program.gameField[i, j + 1])
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
        public static bool checkVerticalLineWin()
        {
            bool allEqual = true;
            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < LAST_INDEX_GRID; j++)
                {
                    if (Program.gameField[j, i] != Program.gameField[j + 1, i])
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
                if (Program.gameField[i, j] != Program.gameField[i + 1, j + 1])
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
                if (Program.gameField[i, j] != Program.gameField[i - 1, j + 1])
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
