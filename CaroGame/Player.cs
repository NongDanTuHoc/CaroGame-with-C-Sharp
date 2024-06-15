using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    internal class Player
    {
        private static string currentPlayer = "O";
        public static string CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }

        }

        public static void Start()
        {
            do
            {
                Console.WriteLine("Ai là người đi trước!");
                Console.WriteLine("1. Nhấn 1 chọn O");
                Console.WriteLine("2. Nhấn 2 chọn X");

                var choicePlayer = Console.ReadLine();

                if (choicePlayer.Equals("1"))
                {
                    currentPlayer = "O";
                    break;
                }
                else if (choicePlayer.Equals("2"))
                {
                    currentPlayer = "X";
                    break;
                }
                else
                {
                    Console.WriteLine("Thông tin bạn nhập không hợp lệ, vui lòng chọn lại!");
                }
            } while (true);

        }
    }
}
