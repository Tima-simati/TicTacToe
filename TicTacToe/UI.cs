using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace TicTacToe
{
    static public class UI
    {
        //output array to console
        public static string displayTicTacToeArray()
        {
            throw new NotImplementedException();
        }
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
            }else
            {
                return false;
            }            
        }
    }
}
