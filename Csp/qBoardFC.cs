using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csp
{

    internal class qBoardFC
    {
        const int EMPTY = int.MaxValue - 1;
        const int QUEEN = int.MaxValue - 2;
        int nQueens;
        int solution;
        List<List<int>> domain;
        public qBoardFC(int nQueens)
        {
            this.nQueens = nQueens;
            this.solution = 0;
            this.domain = new List<List<int>>();

            List<int> arrayCoord;
            for (int i = 0; i < nQueens; i++)
            {
                arrayCoord = new List<int>();
                for (int j = 0; j < nQueens; j++)
                {
                    arrayCoord.Add(EMPTY);
                }
                domain.Add(arrayCoord);
            }

        }
        public int getNumberOfSolutions()
        {
            return solution;
        }

        public void setNumberOfSolutions(int solution)
        {
            this.solution = solution;
        }
        public int getqBoardFCSize()
        {
            return nQueens;
        }

        public void setqBoardFCSize(int qBoardFCSize)
        {
            this.nQueens = qBoardFCSize;
        }

      

        public bool findSolutionFC(int col)
        {

            if (col >= nQueens)
            {
                solution++;
                //Console.WriteLine("" + col + "\n" + toString());
                return true;
            }//if (col >= qBoardFCSize) {

            for (int i = 0; i < nQueens; i++)
            {
                //if (validSpotFC(col))
                //{
                    if (domain[i][col] == EMPTY)
                    {
                        domain[i][col] = QUEEN;
                       
                        markQueen(i, col);
                     
                        findSolutionFC(col + 1);
                       
                        unmarkQueen(i, col);
                      
                        domain[i][col] = EMPTY;
                    }
            }

            

            return false;
        }
        public void markQueen(int row, int col)
        {
            //Removing slots from domain
            for (int j = col + 1; j < nQueens; j++)
            {
                if (domain[row][j] == EMPTY)
                {
                    domain[row][j] = col; ;


                }
            }

            //check right/down diagonal
            for (int i = row + 1, j = col + 1; i < nQueens && j < nQueens; i++, j++)
            {
                if (domain[i][j] == EMPTY)
                {
                  
                    domain[i][j] = col;


                }
            }


            //check right/up diagonal
            for (int i = row - 1, j = col + 1; j < nQueens && i >= 0; i--, j++)
            {
                if (domain[i][j] == EMPTY)
                {
                    domain[i][j] = col;

                }
            }
        }

        public void unmarkQueen(int row, int col)
        {
            //Fixing slots from domain front
            for (int j = col + 1; j < nQueens; j++)
            {
                if (domain[row][j] == col)
                {
                    domain[row][j] = EMPTY;

                }
            }

            //Fixing right/down diagonal
            for (int i = row + 1, j = col + 1; i < nQueens && j < nQueens; i++, j++)
            {
                if (domain[i][j] == col)
                {
                    domain[i][j] = EMPTY;

                }
            }

            //Fixing right/up diagonal
            for (int i = row - 1, j = col + 1; j < nQueens && i >= 0; i--, j++)
            {
                if (domain[i][j] == col)
                {
                    domain[i][j] = EMPTY;

                }
            }
        }

        public String toString()
        {
            Console.WriteLine( "Current Number of Solutions: " + solution + "\n");

            string o = "";
            for (int i = 0; i < nQueens; i++)
            {
            o += "| ";

                for (int j = 0; j < nQueens; j++)
                {
                o += domain[i][j] + " ";
                }
            o += "| \n";
            }
            return o;
        }
    }
}
