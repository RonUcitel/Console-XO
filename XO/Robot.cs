using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Robot
    {
        static bool isFull;
        static int x, y;
        static Random xValue;
        static Random yValue;
        public Robot()
        {
            isFull = true;
            xValue = new Random();
            yValue = new Random();
        }
        static public bool Move(Board board)
        {
            System.Threading.Thread.Sleep(500);
            isFull = true;
            while (isFull)
            {
                x = xValue.Next(Board.length);
                y = xValue.Next(Board.length);
                if (board.Get(x, y) == 0)
                {
                    isFull = false;
                    board.Put(x, y, 2);
                    return true;
                }
            }
            return false;
        }
    }
}
