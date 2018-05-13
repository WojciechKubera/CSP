using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class Board
    {
        protected const int VALUE_NOT_ASSIGNED = -1;
        protected int N;
        protected int[][] fields;

        public Board(int N)
        {
            this.N = N;
            fields = new int[N][];
            initBoard();
        }

        public Board(Board other)
        {
            this.N = other.N;
            this.fields = new int[N][];
            for (int row = 0; row < N; row++)
            {
                fields[row] = new int[N];
            }
            for (int i = 0; i < N; i++)
            {
                Array.Copy(other.fields[i], fields[i], fields.Length);
            }
        }

        protected void initBoard()
        {
            for (int row = 0; row < N; row++)
            {
                fields[row] = new int[N];
                for (int col = 0; col < N; col++)
                {
                    fields[row][col] = VALUE_NOT_ASSIGNED;
                }
            }
        }

        public void setValue(int row, int col, int value)
        {
            fields[row][col] = value;
        }

        public void removeValue(int row, int col)
        {
            fields[row][col] = VALUE_NOT_ASSIGNED;
        }

        public bool checkValues(int row, int column, int value)
        {
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (r == row && c != column)
                    {
                        if (fields[row][c] == value)
                        {
                            return false;
                        }
                    }
                    if (c == column && r != row)
                    {
                        if (fields[r][column] == value)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool[] getUsedValues(int row, int column)
        {
            bool[] used = new bool[N];
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (r == row && c != column)
                    {
                        int val = fields[row][c];
                        if (val != VALUE_NOT_ASSIGNED)
                        {
                            used[val] = true;
                        }
                    }
                    if (c == column && r != row)
                    {
                        int val = fields[r][column];
                        if (val != VALUE_NOT_ASSIGNED)
                        {
                            used[val] = true;
                        }
                    }
                }
            }
            return used;
        }

        
    public String toString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    sb.Append(fields[row][col]).Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }


        public bool equals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Board board = (Board)o;
            return N == board.N && (fields.SequenceEqual( board.fields));
        }


        public int hashCode()
            {
            int result = GetHashCode();
            result = 31 * result + GetHashCode() ;
                return result;
            }

        //public String getFlatSolution()
        //{
        //    return Arrays.deepToString(fields);
        //}
    }
}

