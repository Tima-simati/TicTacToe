namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic.newGameField();
            //Logic.playDecisionMakerAI();
            UI.displayTicTacToeArray(Logic.gameField);
            
            UI.playerInput();
            Logic.gameProgressTracker();


        }
    }
}
