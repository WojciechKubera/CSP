using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class ForwardChecking : LatinSquareAlgorithm
    {
        public ForwardChecking(int N, Board board, List<int> domain) : base(N, board, domain)
        {
        }

        
    public override bool findAll()
        {
            return forwardRowAll(START);
        }

        protected bool forwardRowAll(int currentRow)
        {
            recursiveCalls++;
            if (currentRow == N)
            {
                if (!solutions.Contains(board))
                {
                    solutions.Add(getCopyBoard());
                    returnCount++;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return forwardColAll(currentRow, START);
        }

        protected bool forwardColAll(int row, int currentColumn)
        {
            recursiveCalls++;
            if (currentColumn == N)
            {
                return forwardRowAll(row + 1);
            }

            bool[] usedValues = board.getUsedValues(row, currentColumn);

            for (int i = 0; i < N; i++)
            {
                if (!usedValues[i])
                {
                    int val = domain[i];
                    board.setValue(row, currentColumn, val);
                    if (isBoardOK(row, currentColumn, val) && forwardColAll(row, currentColumn + 1))
                    {
                        return true;
                    }
                    else
                    {
                        board.removeValue(row, currentColumn);
                    }
                }
            }
            returnCount++;
            return false;
        }

        
    public override bool find()
        {
            return forwardRow(START);
        }

        protected bool forwardRow(int currentRow)
        {
            if (currentRow == N)
            {
                return true;
            }
            recursiveCalls++;
            return forwardCol(currentRow, START);
        }

        protected bool forwardCol(int row, int currentColumn)
        {
            if (currentColumn == N)
            {
                recursiveCalls++;
                return forwardRow(row + 1);
            }

            bool[] usedValues = board.getUsedValues(row, currentColumn);

            for (int i = 0; i < N; i++)
            {
                if (!usedValues[i])
                {
                    int val = domain[i];
                    board.setValue(row, currentColumn, val);
                    recursiveCalls++;
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

        
    public override String whoami()
        {
            return "FC";
        }
    }
}

