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
       
        public static void DisplayWelcomeScreen()
        {
            Console.WriteLine("Hi there. Let's play a friendly round of TicTacToe.");
        }
        //output array to console
        /// <summary>
        /// method to display the current gameField; a grid around the symbols will also be added
        /// </summary>
        /// <param name="array2D">only a 2D array can be chosen</param>
        public static void DisplayTicTacToeArray(string[,] array2D)
        {
            int gridLineBetween = array2D.GetLength(1) * 4;
            string gridLines = "-";

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
                    Console.Write(CenterText(array2D[i, j], 3));
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
        public static int InsertPlayerInput(string[,] field)
        {
            int rows = 3, columns = 3; //for indices of User Interface Field
            string[,] fieldChooseArray = new string[rows, columns]; //User interface field
            int chiffre = 1; //for player symbol position initialization
            bool existsInList = false; //bool var to check if playerInput is valid

            List<int> possibleChoices = new List<int>();
            //user interface array to visualize for player to see, which field is empty
            for (int i = 0; i < fieldChooseArray.GetLength(0); i++)
            {
                for (int j = 0; j < fieldChooseArray.GetLength(1); j++)
                {
                    if (field[i, j] == "X" || field[i, j] == "O")
                    {
                        fieldChooseArray[i, j] = " ";
                        chiffre++;
                    }
                    else
                    {
                        possibleChoices.Add(chiffre);
                        string inputField = Convert.ToString(chiffre++).PadLeft(2).PadRight(3);
                        fieldChooseArray[i, j] = inputField.Pastel(Color.Green);
                    }

                }
            }
            Console.WriteLine("Please choose, where you want to put your symbol next.\n Choose your placement according to the green free fields.");
            Console.WriteLine($"Fields available are: {string.Join(", ", possibleChoices)}");

            DisplayTicTacToeArray(fieldChooseArray);
            int playerInput = 0;
            int.TryParse(Console.ReadLine(), out playerInput);
            while (existsInList == false)
            {
                if (possibleChoices.Contains(playerInput))
                {
                    break;
                }
                Console.WriteLine($"Position {playerInput} is not available. Fields available are: {string.Join(", ", possibleChoices)}. Choose:");
                int.TryParse(Console.ReadLine(), out playerInput);
            }
            return playerInput;
        }
        //Display message if player wins
        public static void DisplayPlayerWins()
        {
            Console.WriteLine("Congratulations, you won!");
        }
        //Display message if player loses
        public static void DisplayPlayerLoses()
        {
            Console.WriteLine("You lost. Try next time.");
        }
        //Display message if player ties
        public static void DisplayPlayerTies()
        {
            Console.WriteLine("Oh! A Tie. Nobody wins, nobody loses.");
        }
        //Give player Choice, which symbol he wants to use
        public static int ChoosePlayerSymbol()
        {
            throw new NotImplementedException();
        }
        public static void CleanScreen()
        {
            Console.Clear();
        }
        public static bool StartNewGame()
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
