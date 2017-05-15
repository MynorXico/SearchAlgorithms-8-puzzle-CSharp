using System;
using System.Collections.Generic;
namespace _8Puzzle_SearchAlgorithms_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            int[] array = { 1, 2, 5, 3, 4, 0, 6, 7, 8 };
            for(int i = 0; i < array.Length; i++)
            {
                Numbers.Add(array[i]);
            }
            Solver s = new Solver("bfs");
            s.Solve(Numbers);
        }
    }
}