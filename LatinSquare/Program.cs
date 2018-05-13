using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquare
{
    class Program
    {
        public static List<int> getDomain(int N)
        {
            List<int> domain = new List<int>();
            for (int i = 0; i < N; i++)
            {
                domain.Add(i);
            }
            return domain;
        }
        static void Main(string[] args)
        {
            

            int N = 1;
            List<int> domain = getDomain(N);
            Stopwatch sw = new Stopwatch();
            Board boardFc = new Board(N);
            ForwardChecking fc = new ForwardChecking(N, boardFc, domain);

            sw.Start();
            fc.findAll();
            sw.Stop();
            Console.WriteLine(fc.whoami());
            Console.WriteLine("Amount of solution : "+fc.getSolutions().Count());
            //Console.WriteLine(fc.getReturnCount());
            //Console.WriteLine(fc.getRecursiveCalls());
            Console.WriteLine("Duration: " + sw.ElapsedTicks + " milsek");
            sw.Reset();

           Console.WriteLine();


            Board boardBt = new Board(N);
            Backtracking bt = new Backtracking(N, boardBt, domain);

            sw.Start();
            bt.findAll();
           
            sw.Stop();

            Console.WriteLine(bt.whoami());
            //Console.WriteLine(bt.getReturnCount());
            //Console.WriteLine(bt.getRecursiveCalls());
            Console.WriteLine("Amount of solution : " + bt.getSolutions().Count());
            Console.WriteLine("Duration: " + sw.ElapsedTicks + " milsek");
            sw.Reset();

            Console.WriteLine();


            //Board boardHeurVal = new Board(N);
            //HeuristicSelectValue heurVal = new HeuristicSelectValue(N, boardHeurVal, domain);

            //sw.Start();
            //heurVal.find();
            //sw.Stop();
            //Console.WriteLine(heurVal.whoami());
            //Console.WriteLine(heurVal.getSolutions().Count());
            //Console.WriteLine("Duration: " + sw.ElapsedMilliseconds + " milsek");
            //sw.Reset();


            //Console.WriteLine();


            //Board boardHeurVar = new Board(N);
            //HeuristicSelectVariable heurVar = new HeuristicSelectVariable(N, boardHeurVar, domain);

            //sw.Start();
            //heurVar.find();
            //sw.Stop();
            //Console.WriteLine(heurVar.whoami());
            //Console.WriteLine(heurVar.getSolutions().Count());
            //Console.WriteLine("Duration: " + sw.ElapsedMilliseconds + " milsek");
            //sw.Reset();
        }

        //private static void save(HashSet<Board> solutions, int N, boolean isBT)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    for (Board b : solutions)
        //    {
        //        builder.append(b.getFlatSolution()).append("\n");
        //    }
        //    String alg = isBT ? "BT" : "FC";
        //    Utils.writeResultsToFile(builder, N + "_" + alg);
        //}

    
    }
}
