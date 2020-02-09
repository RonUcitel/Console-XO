using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Board
    {
        public static int length;
        string board;
        bool isFull;
        string[,] gameBoard;
        int[,] playerBoard; // 1- X player;  2- O player;  0- empty;
        public Board(int duration)
        {
            length = duration;
            isFull = false;
            playerBoard = new int[length, length];

            gameBoard = new string[2 * length - 1, 2 * length - 1];
            bool sign = false;
            for (int y = 0; y < 2 * length - 1; y++)
            {
                sign = false;
                if (y%2 == 0)
                {
                    for (int x = 0; x < 2 * length - 1; x++)
                    {
                        if (sign)
                        {
                            gameBoard[y, x] = "|";
                        }
                        else
                        {
                            gameBoard[y, x] = " ";
                        }
                        sign = !sign;
                    }
                }
                else
                {
                    for (int x = 0; x < 2 * length - 1; x++)
                    {
                        if (sign)
                        {
                            gameBoard[y, x] = "|";
                        }
                        else
                        {
                            gameBoard[y, x] = "-";
                        }
                        sign = !sign;
                    }
                }
            }





            /*{
                { " ", "|", " ", "|", " "},
                                        { "-", "|", "-", "|", "-"},
                                        { " ", "|", " ", "|", " "},
                                        { "-", "|", "-", "|", "-"},
                                        { " ", "|", " ", "|", " "}
            }*/
        }

        public int Get(int x, int y)
        {
            if ((x >= 0 && x < length) && (y >= 0 && y < length))
            {
                return playerBoard[y, x];
            }
            else
            {
                return 3; //the cordinats are out of bondes
            }
        }

        public string ShowBoard()
        {
            board = "";
            for (int y = 0; y < (gameBoard.GetLength(0)); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    board += gameBoard[y, x];
                }
                if (y != gameBoard.GetLength(0) - 1)
                {
                    board += "\n";
                }
            }
            return board;
        }

        public bool Put(int x, int y, int player)
        {
            if (MainProgram.illegalFlag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("The coordinates you have enterd are illegal!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                MainProgram.illegalFlag = false;
                return false;
            }
            if (((x >= 0 && x < length) && (y >= 0 && y < length)) && playerBoard[y, x] == 0)
            {
                playerBoard[y, x] = player;
                SetGameBoard();
                return true;//the oparation completed
            }
            else
            {
                if (((x >= 0 && x < length) && (y >= 0 && y < length)) && playerBoard[y, x] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("The coordinates you have enterd have been used!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                else if (!((x >= 0 && x < length) && (y >= 0 && y < length)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("The coordinates you have enterd are out of range!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                return false; //cant do the oparation
            }
        }
        public bool IsBoardFull()
        {
            isFull = true;
            for (int y = 0; y < (playerBoard.GetLength(0)); y++)
            {
                for (int x = 0; x < playerBoard.GetLength(1); x++)
                {
                    if (playerBoard[y, x] == 0)
                    {
                        isFull = false;
                    }
                }
            }
            return isFull;
        }

        void SetGameBoard()
        {
            for (int y = 0; y < (playerBoard.GetLength(0)); y++)
            {
                for (int x = 0; x < (playerBoard.GetLength(0)); x++)
                {
                    if (playerBoard[y, x] == 1)
                    {
                        gameBoard[2 * y, 2 * x] = "X";
                    }
                    if (playerBoard[y, x] == 2)
                    {
                        gameBoard[2 * y, 2 * x] = "O";
                    }
                }
            }
        }


        public bool CheckForUnwin(int player)
        {
            //win in a row
            bool notWin = false;
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    if (playerBoard[y, x] != player)
                    {
                        notWin = true;
                    }
                }
                if (!notWin)
                {
                    return false;
                }
                notWin = false;
            }
            notWin = false;
            //----------------------------------------------------------------------------
            // win in a column
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (playerBoard[y, x] != player)
                    {
                        notWin = true;
                    }
                }
                if (!notWin)
                {
                    return false;
                }
                notWin = false;
            }
            notWin = false;
            //-------------------------------------------------------------------------------
            // win in top to bottom (left to right)
            for (int x = 0; x < length; x++)
                {
                    if (playerBoard[x, x] != player)
                    {
                        notWin = true;
                    }
                }
                if (!notWin)
                {
                    return false;
                }
            notWin = false;
            //-------------------------------------------------------------------------------
            // win in top to bottom (right to left)
            for (int x = 0; x < length; x++)
            {
                if (playerBoard[length-1-x, x] != player)
                {
                    notWin = true;
                }
            }
            if (!notWin)
            {
                return false;
            }
            //--------------------------------------------------------------
            //else
            return true;
        }
    }
}
