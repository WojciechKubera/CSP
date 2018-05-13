using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class HeuristicSelectVariable : LatinSquareAlgorithm
    {
        protected bool side; // false - left, true - right

        public HeuristicSelectVariable(int N, Board board, List<int> domain) : base(N, board, domain)
        {
            side = false;
        }

        
    public override bool findAll()
        {
            return false;
        }

        
    public override bool find()
        {
            return forwardRow(START);
        }

        protected bool forwardRow(int currentRow)
        {
            return currentRow == N || forwardCol(currentRow, START);
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
                int index = side ? (N - i - 1) : i;
                if (!usedValues[index])
                {
                    side = !side;
                    int val = domain[index];
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


        
    public override String whoami()
        {
            return "HEUR_SELECT_VARIABLE";
        }
    }
}

