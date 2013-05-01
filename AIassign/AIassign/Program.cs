//Mike Reisterer
//5820 AI
//Class: Program.cs
//What it does : program uses production systems in order to solve the sliding puzzle from previous assignments
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AIassign
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter outputFile = new StreamWriter("../../../outputFile.txt", true);
            //StreamWriter outputFile = new StreamWriter("../../../outputFile.txt");
            string NextState = "123804765"; //Will also act as initial state  // 2 8 3
            Queue<string> PrevState = new Queue<string>();
            PrevState.Enqueue("123804765");                                   // 1 6 4
            string GoalState = "283164705";                                   // 7 0 5

            //string NextState = "283164705"; //Will also act as initial state  // 2 8 3
            //Queue<string> PrevState = new Queue<string>();
            //PrevState.Enqueue("283164705");                                   // 1 6 4
            //string GoalState = "123804765";                                   // 7 0 5

            List<string> closed = new List<string>();            
            bool isLoop = false;
            bool deadEnd = false;            
            string direction = "";
            int index = 4;
            //int index = 7;
            int flag1 = 0;
            int flag2 = 0;
            int flag3 = 0;
            int flag4 = 0;
            
            closed.Add(NextState);           

            //outputFile.WriteLine("GOAL-DRIVEN********************************************************************************************************************************************");
            outputFile.WriteLine("DATA-DRIVEN********************************************************************************************************************************************");
            outputFile.WriteLine();
            while (NextState != GoalState)
            {
                flag1 = 0;
                flag2 = 0;
                flag3 = 0;
                flag4 = 0;
          
                index = NextState.IndexOf('0');
                if (index != 0 && index != 3 && index != 6) // if not on left edge
                {
                    if (direction == "left" && deadEnd == true)
                    {

                    }
                    else
                    {
                        flag1 = 1;
                        NextState = Fire(flag1, index, NextState.ToCharArray());
                        isLoop = CheckLoop(NextState, closed);
                        if (isLoop == false)
                        {
                            closed.Insert(~closed.BinarySearch(NextState), NextState);                            
                            PrevState.Enqueue(NextState);                            
                            outputFile.Write("Left, ");
                            direction = "left";
                            deadEnd = false;
                            continue;
                        }
                        else
                        {
                            NextState = PrevState.Peek();
                            flag1 = 0;
                        }
                    }
                        
                }
                if (index != 0 && index != 1 && index != 2) //if not on top edge
                {
                    if (direction == "up" && deadEnd == true)
                    {

                    }
                    else
                    {
                        flag2 = 2;
                        NextState = Fire(flag2, index, NextState.ToCharArray());
                        isLoop = CheckLoop(NextState, closed);
                        if (isLoop == false)
                        {
                            closed.Insert(~closed.BinarySearch(NextState), NextState);
                            PrevState.Enqueue(NextState);                          
                            outputFile.Write("Up, ");
                            direction = "up";
                            deadEnd = false;
                            continue;
                        }
                        else
                        {
                            NextState = PrevState.Peek();
                            flag2 = 0;
                        }
                    }
                }
                if (index != 2 && index != 5 && index != 8) // if not on right edge
                {
                    if (direction == "right" && deadEnd == true)
                    {

                    }
                    else
                    {
                        flag3 = 3;
                        NextState = Fire(flag3, index, NextState.ToCharArray());
                        isLoop = CheckLoop(NextState, closed);
                        if (isLoop == false)
                        {
                            closed.Insert(~closed.BinarySearch(NextState), NextState);
                            PrevState.Enqueue(NextState);                           
                            outputFile.Write("Right, ");
                            direction = "right";
                            deadEnd = false;
                            continue;
                        }
                        else
                        {
                            NextState = PrevState.Peek();
                            flag3 = 0;
                        }
                    }
                }
                if (index != 8 && index != 7 && index != 6) //index is not on bottom edge
                {
                    if (direction == "down" && deadEnd == true)
                    {

                    }
                    else
                    {
                        flag4 = 4;
                        NextState = Fire(flag4, index, NextState.ToCharArray());
                        isLoop = CheckLoop(NextState, closed);
                        if (isLoop == false)
                        {
                            closed.Insert(~closed.BinarySearch(NextState), NextState);
                            PrevState.Enqueue(NextState);                           
                            outputFile.Write("Down, ");
                            direction = "down";
                            deadEnd = false;
                            continue;

                        }
                        else
                        {
                            NextState = PrevState.Peek();
                            flag4 = 0;
                        }
                    }
                }  
            
                //if all cases fall through we are at a dead end..and so...                
                NextState = PrevState.Dequeue();               
                deadEnd = true;

            }

            outputFile.WriteLine(Environment.NewLine + "This is the answer: "+ NextState + " Number of Iterations: " + closed.Count);
            outputFile.Close();
        }

        public static string Fire(int Case, int index, char[] TempArray)
        {
            char placeHolder;         
            switch (Case)
            {
                case 1:
                    placeHolder = TempArray[index];
                    TempArray[index] = TempArray[index - 1]; // Go left
                    TempArray[index - 1] = placeHolder;
                    break;

                case 2:
                    placeHolder = TempArray[index];
                    TempArray[index] = TempArray[index - 3]; //Go up
                    TempArray[index - 3] = placeHolder;
                    break;

                case 3:
                    placeHolder = TempArray[index];
                    TempArray[index] = TempArray[index + 1]; // Go Right
                    TempArray[index + 1] = placeHolder;
                    break;

                case 4:
                    placeHolder = TempArray[index];
                    TempArray[index] = TempArray[index + 3]; // Go Down
                    TempArray[index + 3] = placeHolder;
                    break;
            }
            string returnArray = new string(TempArray);            
            
            return returnArray;
        }

        public static bool CheckLoop(string Next, List<string> Closed)
        {
            if (Closed.BinarySearch(Next) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }
    }
}
