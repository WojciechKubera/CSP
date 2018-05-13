using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class LatinSquarePuzzle
    {
        protected const int START_ROW = 0;
        protected int N;
        protected Board board;
        protected List<int> domain;
        protected HashSet<Board> solutions;

        public LatinSquarePuzzle(Board board, int N, List<int> domain, HashSet<Board> solutions)
        {
            this.board = board;
            this.N = N;
            this.domain = domain;
            this.solutions = solutions;
        }

        public bool solveUsingBacktracking()
        {
            return backRow(START_ROW);
        }

        protected bool backRow(int currentRow)
        {
            if (currentRow == N)
            {
                if (!solutions.Contains(board))
                {
                    solutions.Add(getCopyBoard());
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return backCol(currentRow, START_ROW);
        }

        protected bool backCol(int row, int currentColumn)
        {
            if (currentColumn == N)
            {
                return backRow(row + 1);
            }
            foreach (int dom in domain)
            {
                board.setValue(row, currentColumn, dom);
                if (isBoardOK(row, currentColumn, dom) && backCol(row, currentColumn + 1))
                {
                    return true;
                }
                else
                {
                    board.removeValue(row, currentColumn);
                }
            }
            return false;
        }

        public bool solveUsingForwardChecking()
        {
            return forwardRow(START_ROW);
        }

        protected bool forwardRow(int currentRow)
        {
            if (currentRow == N)
            {
                if (!solutions.Contains(board))
                {
                    solutions.Add(getCopyBoard());
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return forwardCol(currentRow, START_ROW);
        }

        protected bool forwardCol(int row, int currentColumn)
        {
            if (currentColumn == N)
            {
                return forwardRow(row + 1);
            }

            bool[] usedValues = board.getUsedValues(row, currentColumn);

            for (int i = 0; i < N; i++)
            {
                if (!usedValues[i])
                {
                    int val = domain[i];
                    board.setValue(row, currentColumn, val);
                    if (isBoardOK(row, currentColumn, val) && forwardCol(row, currentColumn + 1))
                    {
                        return true;
                    }
                    else
                    {
                        board.removeValue(row, currentColumn);
                    }
                }
            }
            return false;
        }

        protected bool isBoardOK(int row, int col, int val)
        {
            return board.checkValues(row, col, val);
        }

        protected Board getCopyBoard()
        {
            return new Board(board);
        }
    }
}

