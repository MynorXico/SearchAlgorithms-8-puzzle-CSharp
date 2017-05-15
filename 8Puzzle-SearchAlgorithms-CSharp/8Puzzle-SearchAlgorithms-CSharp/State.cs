using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace _8Puzzle_SearchAlgorithms_CSharp
{
    class State
    {
        public List<int> CurrentBoard;
        public int ZeroPosition;
        string Movement = "";
        public State(List<int> Numbers)
        {
            CurrentBoard = Numbers;
            ZeroPosition = Numbers.IndexOf(0);
        }

        public void GenerateChildren(List<List<int>> VisitedMatrices, Queue<List<int>> FrontierMatrices, Queue<State> FrontierStates)
        {
            // Can move Up
            if(ZeroPosition/3 != 0)
            {
                List<int> tmpMatrix = MoveUp();
                if (!(ListInListOfLists(tmpMatrix, VisitedMatrices) || ListInListOfLists(tmpMatrix, FrontierMatrices)))
                {
                    State tmpState = new State(tmpMatrix)
                    {
                        Movement = Movement + "U",
                        ZeroPosition = ZeroPosition - 3
                    };
                    FrontierStates.Enqueue(tmpState);
                    FrontierMatrices.Enqueue(tmpMatrix);
                }
            }

            // Can move Down
            if (ZeroPosition / 3 != 2)
            {
                List<int> tmpMatrix = MoveDown();
                if (!(ListInListOfLists(tmpMatrix, VisitedMatrices) || ListInListOfLists(tmpMatrix, FrontierMatrices)))
                {
                    State tmpState = new State(tmpMatrix)
                    {
                        Movement = Movement + "D",
                        ZeroPosition = ZeroPosition + 3
                    };
                    FrontierStates.Enqueue(tmpState);
                    FrontierMatrices.Enqueue(tmpMatrix);
                }
            }
            // Can move Left
            if (ZeroPosition % 3 != 0)
            {
                List<int> tmpMatrix = MoveLeft();
                if (!(ListInListOfLists(tmpMatrix, VisitedMatrices) || ListInListOfLists(tmpMatrix, FrontierMatrices)))
                {
                    State tmpState = new State(tmpMatrix)
                    {
                        Movement = Movement + "L",
                        ZeroPosition = ZeroPosition - 1
                    };
                    FrontierStates.Enqueue(tmpState);
                    FrontierMatrices.Enqueue(tmpMatrix);
                }
            }
            // Can move Right
            if (ZeroPosition % 3 != 2)
            {
                List<int> tmpMatrix = MoveRight();
                if (!(ListInListOfLists(tmpMatrix, VisitedMatrices) || ListInListOfLists(tmpMatrix, FrontierMatrices)))
                {
                    State tmpState = new State(tmpMatrix)
                    {
                        Movement = Movement + "R",
                        ZeroPosition = ZeroPosition + 1
                    };
                    FrontierStates.Enqueue(tmpState);
                    FrontierMatrices.Enqueue(tmpMatrix);
                }
            }
        }

        public void PrintStatePath()
        {
            Console.WriteLine(Movement);
        }

        public List<int> MoveUp()
        {
            List<int> tmpBoard = copyList(CurrentBoard);
            int tmp = tmpBoard[this.ZeroPosition];
            tmpBoard[this.ZeroPosition] = tmpBoard[this.ZeroPosition - 3];
            tmpBoard[this.ZeroPosition - 3] = tmp;
            return tmpBoard;
        }

        public List<int> MoveDown()
        {
            List<int> tmpBoard = copyList(CurrentBoard);
            int tmp = tmpBoard[this.ZeroPosition];
            tmpBoard[this.ZeroPosition] = tmpBoard[this.ZeroPosition + 3];
            tmpBoard[this.ZeroPosition + 3] = tmp;
            return tmpBoard;
        }
        public List<int> MoveLeft()
        {
            List<int> tmpBoard = copyList(CurrentBoard);
            int tmp = tmpBoard[this.ZeroPosition];
            tmpBoard[this.ZeroPosition] = tmpBoard[this.ZeroPosition -1];
            tmpBoard[this.ZeroPosition -1] = tmp;
            return tmpBoard;
        }
        public List<int> MoveRight()
        {
            List<int> tmpBoard = copyList(CurrentBoard);
            int tmp = tmpBoard[this.ZeroPosition];
            tmpBoard[this.ZeroPosition] = tmpBoard[this.ZeroPosition + 1];
            tmpBoard[this.ZeroPosition + 1] = tmp;
            return tmpBoard;
        }

        public int GetZeroPosition()
        {
            return CurrentBoard.IndexOf(0);
        }

        public List<int> copyList(List<int> Original)
        {
            List<int> Copia = new List<int>();
            for(int i = 0; i < Original.Count; i++)
            {
                Copia.Add(Original[i]);
            }
            return Copia;
        }

        bool ListInListOfLists(List<int> query, IEnumerable<List<int>> ListOfLists)
        {
            foreach(List<int> list in ListOfLists)
            {
                if (list.SequenceEqual(query))
                    return true;
            }
            return false;
        }
    }
}
