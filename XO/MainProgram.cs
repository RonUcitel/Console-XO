using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class MainProgram
    {
        public static bool illegalFlag;
        static string input;
        static bool player;
        static bool posible;
        static Board board;
        static void Main(string[] args)
        {
            illegalFlag = false;
            Robot robot = new Robot();
            player = true; //true = 1 = X, false = 2 = O
            Console.Write("Enter the size of the board: ");
            bool working = false;
            while (!working)
            {
                try
                {
                    Console.Write("Enter the size of the board: ");
                    board = new Board(int.Parse(Console.ReadLine()));
                    working = true;
                }
                catch
                {
                    Console.Clear();
                    working = false;
                }
            }
            Console.Clear();
            Console.WriteLine(board.ShowBoard());

            while (!board.IsBoardFull() && board.CheckForUnwin(1) && board.CheckForUnwin(2))
            {
                if (player)
                {
                    input = Console.ReadLine();
                }
                if (!player /*&& (GetCoordinates(input)[0] != Board.length || GetCoordinates(input)[1] != Board.length)*/)
                {
                    //posible = board.Put(GetCoordinates(input)[0], GetCoordinates(input)[1], 2);// O
                    Robot.Move(board);
                }
                else// if(GetCoordinates(input)[0] != Board.length || GetCoordinates(input)[1] != Board.length)
                {
                    posible = board.Put(GetCoordinates(input)[0], GetCoordinates(input)[1], 1);// X
                }
                Console.Clear();
                Console.WriteLine(board.ShowBoard());
                if (posible && GetCoordinates(input)[0] < Board.length)//if (/*(GetCoordinates(input)[0] < Board.length || GetCoordinates(input)[1] < Board.length)&&*/ board.Get(GetCoordinates(input)[0], GetCoordinates(input)[1]) ==0)
                    player = !player;
            }
            if (!board.CheckForUnwin(1))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Player X has won the game");
                Console.ReadKey();
            }
            else if(!board.CheckForUnwin(2))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Player O has won the game");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("It's a draw!");
                Console.ReadKey();
            }
            
        }

        static int[] GetCoordinates(string value)
        {
            int[] coordinates = new int[2];
            try
            {
                coordinates[0] = int.Parse(value.Split(',')[0]);// 
                coordinates[1] = int.Parse(value.Split(',')[1]);// y
                illegalFlag = false;
            }
            catch
            {
                coordinates[0] = Board.length;
                coordinates[1] = Board.length;
                illegalFlag = true;
            }
            return coordinates;
        }

        public static void ShowError(int error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            switch (error)
            {
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("The coordinates you have enterd are illegal!");
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("The coordinates you have enterd are out of range!");
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("The coordinates you have enterd have been used!");
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("The error was wrong!!!!!!");
                        break;
                    }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
