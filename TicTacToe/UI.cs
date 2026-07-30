using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

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
                    Console.Write(Logic.CenterText(array2D[i,j], 3));
                    //Console.Write(CenterText("X", 3));
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine(gridLines);
            }
        }
        /// <summary>
        /// Support Method to put the Text in center with paddig
        /// </summary>
        /// <param name="text">this is the character, string, which needs to be put in center</param>
        /// <param name="width">the width of extra added space</param>
        /// <returns>a new string with the text and padding with spaces to the left and right is added</returns>
       
        //read player input to where to place the symbol
        //think of a way how a user can actually place a symbol into the play area
        public static string playerInput()
        {
            throw new NotImplementedException();
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
        public static bool continueGame()
        {
            Console.WriteLine($"Do you want to conine? Press y then.");
            if (Console.ReadLine() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
