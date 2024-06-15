using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    internal class Board
    {
        public static string[,] cells;
        private static int currentRow = 0;
        public static int CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }
        private static int currentCollumn = 0;
        public static int CurrentCollumn
        {
            get { return currentCollumn; }
            set { currentCollumn = value; }
        }

        public static void InitializeBoard()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập chiều rộng bàn cờ:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập chiều dài bàn cờ:");
            int column = int.Parse(Console.ReadLine());
            cells = new string[2 * row, 2 * column];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                // in ra các cột
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        cells[i, j] = "_";
                    }
                    else if (i % 2 == 0)
                    {
                        cells[i, j] = "|";
                    }
                    // in ra dấu gạch dưới
                    else
                    {
                        cells[i, j] = ("-");
                    }
                }

            }
        }

        public static void PrintBoard()
        {
            Console.WriteLine("Chào mừng đến với game cờ Caro!");
            Console.WriteLine();
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                // in ra các cột
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (i == currentRow && j == currentCollumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(cells[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();

            }
        }
    }
}
