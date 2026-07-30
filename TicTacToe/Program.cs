namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic.newGameField();
            //Logic.playDecisionMakerAI();
            UI.displayTicTacToeArray(Logic.gameField);
            
            int position = UI.playerInput();
            Logic.gameProgressTracker(position);
            UI.displayTicTacToeArray(Logic.gameField);


        }
    }
}
