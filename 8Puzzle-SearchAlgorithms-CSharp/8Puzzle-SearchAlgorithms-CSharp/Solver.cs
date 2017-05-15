using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _8Puzzle_SearchAlgorithms_CSharp
{
    class Solver
    {
        Stopwatch sw = new Stopwatch();

        Queue<State> FrontierStates = new Queue<State>();
        int NodesExpaned = 0;
        Queue<List<int>> FrontierMatrices = new Queue<List<int>>();
        List<List<int>> VisitedMatrices = new List<List<int>>();
        int ZeroPosition = 0;
        string Method = "";
        List<int> GoalNumbers = new List<int>();
        State tmpState;
        public Solver(string method)
        {
            Method = method;
            sw.Start();
        }

        public bool Solve(List<int> Numbers)
        {
            // Creates Goal State
            for(int i = 0; i < 9; i++)
            {
                GoalNumbers.Add(i);
            }
            State GoalState = new State(GoalNumbers);

            // Creates Initial State
            State InitialState = new State(Numbers);
            InitialState.ZeroPosition = InitialState.GetZeroPosition();

            FrontierStates.Enqueue(InitialState);
            FrontierMatrices.Enqueue(InitialState.CurrentBoard);

            while(FrontierStates.Count != 0)
            {
                if(VisitedMatrices.Count % 1000 == 0)
                {
                    Console.WriteLine(VisitedMatrices.Count);
                    Console.WriteLine(sw.Elapsed.TotalSeconds);
                }
                if (Method == "bfs") {
                    tmpState = FrontierStates.Dequeue();
                    FrontierMatrices.Dequeue();
                }
                VisitedMatrices.Add(tmpState.CurrentBoard);
                if(GoalState.CurrentBoard == tmpState.CurrentBoard)
                {
                    tmpState.PrintStatePath();
                    Console.WriteLine($"{sw.Elapsed.TotalSeconds} ({VisitedMatrices.Count})");
                    return true;
                }
                tmpState.GenerateChildren(VisitedMatrices, FrontierMatrices, FrontierStates);
            }
            Console.WriteLine("False");
            return false;
        }
    }
}
