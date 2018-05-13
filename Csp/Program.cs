using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Csp
{
    class Program
    {
        static byte nQueens = 15;
        static int solution = 0;
        List<List<char>> domain = new List<List<char>>();

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            qBoardFC fcBoard = new qBoardFC(nQueens);
            bool[,] board = new bool[nQueens, nQueens];
            for (int i = 0; i < nQueens; i++)
            {
                for (int j = 0; j < nQueens; j++)
                {
                    board[i, j] = false;
                }
            }
            sw.Start();
            //fcBoard.findSolutionFC(0);
            nQueen(board, 0, 0);
            sw.Stop();
            Console.WriteLine("BT");
            Console.WriteLine("Liczba rozwiązań = " + solution);
            Console.WriteLine("Czas wykoananina = " + sw.ElapsedMilliseconds + " milsek");
            
            sw.Reset();
            sw.Start();
            fcBoard.findSolutionFC(0);
            sw.Stop();
            Console.WriteLine("FC");
            Console.WriteLine("Liczba rozwiązań = " + fcBoard.getNumberOfSolutions());
            Console.WriteLine("Czas wykoananina = " + sw.ElapsedMilliseconds + " milsek");
           
        }

      
        static bool isSafe(bool[,] board, int r, int c)
        {
            //column
            for (int i = 0; i < r; i++)
                if (board[i, c] == true)
                    return false;

            //\ diagonal
            for (int i = r, j = c; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == true)
                    return false;

            // / diagonal
            for (int i = r, j = c; i >= 0 && j < nQueens; i--, j++)
                if (board[i, j] == true)
                    return false;

            return true;
        }
        static void nQueen(bool[,] board, int r, int c)
        {
            // solution count            
            if (c == 0 && r == nQueens)
            {
                solution = solution + 1;
                return;
            }
            for (int i = 0; i < nQueens; i++)
            {

                if (isSafe(board, r, i))
                {
                    board[r, i] = true;
                    nQueen(board, r + 1, 0);
                    board[r, i] = false;
                }
            }
        }
    }
}