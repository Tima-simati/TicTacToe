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
            string[,] testfield = new string[3, 3] { { "O", symbolPlayer, symbolPlayer }, { " ", symbolPlayer, " " }, { "O", " ", " " } };
            bool newGame = true;
            int position = 0; //Player Input for position
            UI.DisplayWelcomeScreen();
            gameField = Logic.CreateNewGameField(gameField);
            //gameField = testfield;

            //loop for continue game
            while (newGame)
            {
                //loop for current game turns
                while (!gameResult)
                {

                    UI.DisplayTicTacToeArray(gameField);
                    //Player turn
                    position = UI.InsertPlayerInput(gameField);
                    UI.CleanScreen();
                    Logic.InsertInputInArray(position, gameField, symbolPlayer);
                    Console.WriteLine($"Turn: {turnCounter}"); //Debug line only
                    UI.DisplayTicTacToeArray(gameField);

                    if (Logic.CheckForWin(gameField, symbolPlayer))
                    {
                        UI.DisplayPlayerWins();
                        UI.DisplayTicTacToeArray(gameField);
                        Console.WriteLine($"Turn: {turnCounter}");
                        gameResult = true;
                        break;
                    }
                    turnCounter++;// increase the turn counter
                    //after last possible turn, check if turnCounter is full
                    Console.WriteLine($"Turn: {turnCounter}");
                    if (turnCounter > 8)
                    {
                        UI.DisplayPlayerTies();
                        break;
                    }
                    //CPU turn
                    Logic.PlayDecisionMakerAI(gameField);
                    if (Logic.CheckForWin(gameField, Logic.symbolAI))
                    {
                        UI.DisplayPlayerLoses();
                        UI.DisplayTicTacToeArray(gameField);
                        Console.WriteLine($"Turn: {turnCounter}"); // debug line only
                        gameResult = true;
                        break;
                    }
                    turnCounter++;
                }
                turnCounter = 0; //reset counter
                gameResult = false; //reset gameResult
                gameField = Logic.CreateNewGameField(gameField); //reset playing field
                newGame = UI.StartNewGame();
                UI.CleanScreen();
            }
        }

    }
}



