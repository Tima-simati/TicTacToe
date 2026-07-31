namespace TicTacToe
{
    internal class Program
    {
        public static int turnCounter = 1; //with % operator, I can decide later on which turn Player or AI won
        static void Main(string[] args)
        {
            bool gameResult = true; 
            Logic.newGameField();
            //Logic.playDecisionMakerAI();
            UI.displayTicTacToeArray(Logic.gameField);
            //get player symbol placement choice
            int position = UI.playerInput();
            UI.cleanScreen();

            Logic.insertInputInArray(position);
            UI.displayTicTacToeArray(Logic.gameField);


            
        }
    }
}
