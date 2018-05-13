using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class Backtracking : LatinSquareAlgorithm
    {

        public Backtracking(int N, Board board, List<int> domain) : base(N, board, domain)
        {
            
        }

        
    public override bool findAll()
        {
            return backRowAll(START);
        }

        
    public override bool find()
        {
            return backRow(START);
        }

        protected bool backRowAll(int currentRow)
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
            return backColAll(currentRow, START);
        }

        protected bool backColAll(int row, int currentColumn)
        {
            recursiveCalls++;
            if (currentColumn == N)
            {
                return backRowAll(row + 1);
            }
            foreach (int dom in domain)
            {
                board.setValue(row, currentColumn, dom);
                if (isBoardOK(row, currentColumn, dom) && backColAll(row, currentColumn + 1))
                {
                    return true;
                }
                else
                {
                    board.removeValue(row, currentColumn);
                }
            }
            returnCount++;
            return false;
        }

        protected bool backRow(int currentRow)
        {
            if (currentRow == N)
            {
                return true;
            }
            recursiveCalls++;
            return backCol(currentRow, START);
        }

        protected bool backCol(int row, int currentColumn)
        {
            if (currentColumn == N)
            {
                recursiveCalls++;
                return backRow(row + 1);
            }
            for (int i = 0; i < domain.Count(); i++)
            {
                int dom = domain[i];
                board.setValue(row, currentColumn, dom);
                recursiveCalls++;
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

        
    public override String whoami()
        {
            return "BT";
        }
    }
}

