using System.Text;

namespace CaroGame
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Board.InitializeBoard();
                Board.PrintBoard();
                Player.Start();
                Game.KeyBoardInput();
                if (!Game.GameAgain())
                {
                    Console.WriteLine("Thank you for play!");
                    Task.Delay(2000).Wait();
                    break;
                }
            } while (true);


        }

    }
}