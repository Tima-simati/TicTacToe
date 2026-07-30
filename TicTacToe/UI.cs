using Pastel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToe
{
    static public class UI
    {
        public static string gridLines = "-";
        static int gridLineBetween = Logic.gameField.GetLength(1) * 4;

        //output array to console
        /// <summary>
        /// method to display the current gameField; a grid around the symbols will also be added
        /// </summary>
        /// <param name="array2D">only a 2D array can be chosen</param>
        public static void displayTicTacToeArray(string[,] array2D)
        {
            for (int i = 0; i < gridLineBetween; i++)
            {
                gridLines += "-";
            }
            Console.WriteLine(gridLines);
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.Write(CenterText(array2D[i,j], 3));
                    //Console.Write(CenterText("X", 3));
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine(gridLines);
            }
            //reset of gridLines
            gridLines = "-";
        }
     
        //read player input to where to place the symbol
        //think of a way how a user can actually place a symbol into the play area
        public static int playerInput()
        {
            int row_index = 0;
            int column_index = 0;
            string[,] fieldChooseArray = new string[Logic.rows, Logic.columns];
            int chiffre = 1;
            for (int i = 0; i < fieldChooseArray.GetLength(0); i++)
            {
                for (int j = 0; j < fieldChooseArray.GetLength(1); j++)
                {
                    if (Logic.gameField[i, j] == "X" || Logic.gameField[i, j] == "O")
                    {
                        fieldChooseArray[i, j] = " ";
                        chiffre++;
                    }
                    else
                    {
                        string field = Convert.ToString(chiffre++).PadLeft(2).PadRight(3);
                        fieldChooseArray[i, j] = field.Pastel(Color.Green);
                    }
                }
            }
            Console.WriteLine("Please choose, where you want to put your symbol next.\n Choose your placement according to the free fields 1 to 9.");
            //Funktion einbauen, wo nur verfügbare Zahlen im WriteLine rauskommen
            displayTicTacToeArray(fieldChooseArray);
            int playerInput = 0;
            int.TryParse(Console.ReadLine(), out playerInput);
        
            return playerInput;
        }
        //Display message if player wins
        public static string displayPlayerWins()
        {
            throw new NotImplementedException();
        }
        //Display message if player loses
        public static string displayPlayerLoses()
        {
            throw new NotImplementedException();
        }
        //Display message if player ties
        public static string displayPlayerTies()
        {
            throw new NotImplementedException();
        }
        //Give player Choice, which symbol he wants to use
        public static int choosePlayerSymbol()
        {
            throw new NotImplementedException();
        }
        public static bool startNewGame()
        {
            Console.WriteLine($"Do you want to start a new game? Press y then.");
            if (Console.ReadLine() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
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
