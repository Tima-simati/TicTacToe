namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turnCounter = 1; //with % operator, I can decide later on which turn Player or AI won
            string[,] gameField = new string[Logic.ROWS, Logic.COLUMNS];
            bool gameResult = false;
            string symbolPlayer = "X";
            string[,] testfield = new string[3, 3] { { "X", " ", "O" }, { "X", " ", "O" }, { "X", " ", "O" } };

            int position = 0; //Player Input for position
            UI.DisplayWelcomeScreen();
            gameField = Logic.CreateNewGameField(gameField);

            while (gameResult == false)
            {
                if (turnCounter > 9)
                {
                    UI.DisplayPlayerTies();
                    return;
                }
                UI.DisplayTicTacToeArray(gameField);
                //Player turn
                //position = UI.InsertPlayerInput();
                //UI.CleanScreen();
                //Logic.InsertInputInArray(position, symbolPlayer);
                //UI.DisplayTicTacToeArray(gameField);
                //Logic.CheckForWin();
                //turnCounter++;// increase the turn counter
                ////CPU turn
                //Logic.PlayDecisionMakerAI();
                //Logic.CheckForWin();
                turnCounter++;
            }
            ////game ended on players turn
            //if (turnCounter % 2 == 1)
            //{
            //    UI.displayPlayerWins();
            //}
            ////game ended on CPU turn
            //if (turnCounter % 2 == 0)
            //{
            //    UI.displayPlayerLoses();
            //}

        }
    }
}
