using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    internal class Game
    {
        public static void KeyBoardInput()
        {
            while (true)
            {
                Console.Clear();
                Board.PrintBoard();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    Board.CurrentCollumn += 2;
                    Board.CurrentCollumn = (Board.CurrentCollumn > Board.cells.GetLength(1) - 2) ? Board.cells.GetLength(1) - 2 : Board.CurrentCollumn;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    Board.CurrentCollumn -= 2;
                    Board.CurrentCollumn = (Board.CurrentCollumn < 0) ? 0 : Board.CurrentCollumn;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Board.CurrentRow -= 2;
                    Board.CurrentRow = (Board.CurrentRow < 0 ? 0 : Board.CurrentRow);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Board.CurrentRow += 2;
                    Board.CurrentRow = (Board.CurrentRow > (Board.cells.GetLength(0) - 2)) ? Board.cells.GetLength(0) - 2 : Board.CurrentRow;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string input = Board.cells[Board.CurrentRow, Board.CurrentCollumn];
                    if (input == "_")
                    {
                        Board.cells[Board.CurrentRow, Board.CurrentCollumn] = Player.CurrentPlayer;
                        bool result = CheckVictory(Player.CurrentPlayer, Board.CurrentRow, Board.CurrentCollumn);

                        if (result)
                        {
                            Console.Clear();
                            Board.PrintBoard();
                            Console.WriteLine(Player.CurrentPlayer == "O" ? "Player 1 win" : "Player 2 win");
                            Console.ReadKey();
                            break;
                        }
                        if (!CheckContinue(Board.cells))
                        {
                            Console.Clear();
                            Board.PrintBoard();
                            Console.WriteLine("Hòa");
                            Console.ReadKey();
                            break;
                        }

                        Player.CurrentPlayer = (Player.CurrentPlayer == "O" ? "X" : "O");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chỉ được nhập ở ô trống!");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
            }
        }
        public static bool GameAgain()
        {
            while (true)
            {
                Console.WriteLine("Nhập Y để chơi lại, nhập N để thoát!");

                var choice = Console.ReadLine();

                if (choice.Trim().ToUpper().Equals("Y"))
                {
                    return true;
                }
                else if (choice.Trim().ToUpper().Equals("N"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Thông tin bạn nhập không hợp lệ, vui lòng nhập lại!");
                }
            }
        }

        public static bool CheckContinue(string[,] cells)
        {
            foreach (string item in cells)
            {
                if (item.Equals("_"))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckVictory(string currentPlayer, int CurrentRow, int CurrentCollumn)
        {
            if (CountConsecutive(currentPlayer, CurrentRow, CurrentCollumn, 0, 2) > 3)
            {
                return true;
            }

            if (CountConsecutive(currentPlayer, CurrentRow, CurrentCollumn, 2, 0) > 3)
            {
                return true;
            }

            if (CountConsecutive(currentPlayer, CurrentRow, CurrentCollumn, 2, 2) > 3)
            {
                return true;
            }
            if (CountConsecutive(currentPlayer, CurrentRow, CurrentCollumn, 2, -2) > 3)
            {
                return true;
            }

            return false;
        }

        public static int CountConsecutive(string currentPlayer, int CurrentRow, int CurrentCollumn, int directionRow, int directionColumn)
        {
            int count = 0;
            for (int i = CurrentRow, j = CurrentCollumn; i >= 0 && j >= 0 && i < Board.cells.GetLength(0) && j < Board.cells.GetLength(1) && Board.cells[i, j].Equals(Player.CurrentPlayer); i += directionRow, j += directionColumn)
            {
                count++;
            }

            for (int i = CurrentRow - directionRow, j = CurrentCollumn - directionColumn; i >= 0 && j >= 0 && i < Board.cells.GetLength(0) && j < Board.cells.GetLength(1) && Board.cells[i, j].Equals(Player.CurrentPlayer); i -= directionRow, j -= directionColumn)
            {
                count++;
            }
            return count;
        }
    }
}
