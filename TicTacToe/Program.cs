namespace TicTacToe
{
    internal class Program
    {
        public static int turnCounter = 1; //with % operator, I can decide later on which turn Player or AI won
        public static string[,] gameField = new string[Logic.ROWS, Logic.COLUMNS];
        public static bool gameResult = false;
        public static string symbolPlayer = "X";
        public static string[,] testfield = new string[3, 3] { { "X", " ", "O" }, { "X", " ", "O" }, { "X", " ", "O" } };
        static void Main(string[] args)
        {
            int position = 0; //Player Input for position
            UI.welcomeScreen();
            Logic.newGameField();

            //while (gameResult == false)
            //{
            if (turnCounter > 9)
            {
                UI.displayPlayerTies();
                return;
            }
            UI.displayTicTacToeArray(gameField);
            //Player turn
            position = UI.playerInput();
            UI.cleanScreen();
            Logic.insertInputInArray(position, symbolPlayer);
            UI.displayTicTacToeArray(gameField);
            Logic.checkForWin();
            turnCounter++;// increase the turn counter
            //CPU turn
            Logic.playDecisionMakerAI();
            Logic.checkForWin();
            turnCounter++;
            //}
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
