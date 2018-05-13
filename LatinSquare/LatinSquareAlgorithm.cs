using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    abstract class LatinSquareAlgorithm
    {
        protected const int START = 0;
        protected int N;
        protected Board board;
        protected List<int> domain;
        protected HashSet<Board> solutions = new HashSet<Board>();
        protected int recursiveCalls;
        protected int returnCount;

        public LatinSquareAlgorithm(int N, Board board, List<int> domain)
        {
            this.N = N;
            this.board = board;
            this.domain = domain;
            initCounters();
        }

        public abstract bool findAll();

        public abstract bool find();

        public abstract String whoami();

        protected bool isBoardOK(int row, int col, int val)
        {
            return board.checkValues(row, col, val);
        }

        protected Board getCopyBoard()
        {
            return new Board(board);
        }

        protected void initCounters()
        {
            recursiveCalls = 0;
            returnCount = 0;
        }

        public int getN()
        {
            return N;
        }

        public void setN(int n)
        {
            N = n;
        }

        public Board getBoard()
        {
            return board;
        }

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public List<int> getDomain()
        {
            return domain;
        }

        public void setDomain(List<int> domain)
        {
            this.domain = domain;
        }

        public HashSet<Board> getSolutions()
        {
            return solutions;
        }

        public int getRecursiveCalls()
        {
            return recursiveCalls;
        }

        public int getReturnCount()
        {
            return returnCount;
        }

    }
}
