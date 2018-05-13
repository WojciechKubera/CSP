using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class HeuristicSelectValue : LatinSquareAlgorithm
    {
        public HeuristicSelectValue(int N, Board board, List<int> domain) : base(N, board, domain)
        {
            
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
            List<int> values = new List<int>();
            for (int i = 0; i < N; i++)
            {
                if (!usedValues[i])
                {
                    values.Add(i);
                }
            }

            var rnd = new Random();
            values.OrderBy(item => rnd.Next());
           

            for (int v = 0; v < values.Count(); v++)
            {
                board.setValue(row, currentColumn, values[v]);
                if (isBoardOK(row, currentColumn, values[v]) && forwardCol(row, currentColumn + 1))
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
            return "HEUR_SELECT_VALUE";
        }
    

    }
}
