//Mike Reisterer
//5820 AI
//Due Date: Apr 11, 2013
//Program 8: Tower of Hanoi
//Class: Program.cs
//What it does: Uses my own production system to solve the Tower of Hanoi problem Note all 3 towers are in ONE array. (123) = A (000) = B (000)= C at initialize
//Now it also uses heuristics as well, both solution paths are compared in the output file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] towers = new int[]{ 1, 2, 3, 0, 0, 0, 0, 0, 0 };
             int[][] nextTower = new int[200][];          
             int[] goalState = new int[] { 0, 0, 0, 0, 0, 0, 1, 2, 3 };
             List<int[]> closed = new List<int[]>();
             int count = 0;
             int totalCount = 0; //count includes loops
             closed.Add(towers);           
             int diskA;
             int diskB;
             int diskC;
             int indexA;
             int indexB;
             int indexC;
             int zeroIndex = 0;
             int tempDisk = 0;
             bool isLoop;
             bool deadEnd = false;
             StreamWriter outputFile = new StreamWriter("../../../outputFile.txt");
             nextTower[0] = new int[9];
             Array.Copy(towers, nextTower[0], 9);
            //**************************HW 8 Variables****************************************
             int[][] possibleState = new int[200][];
             possibleState[0] = new int[9];
             Array.Copy(towers, possibleState[0], 9);
             int[] nextPath = new int[9];
             int hcount = 0; //index
             int totalHcount = 0; // number of iterations
             List<Sets> newClosed = new List<Sets>();
             List<Sets> open = new List<Sets>();
             int h = findH(towers, goalState);
             Array.Copy(towers, nextPath, 9);
             newClosed.Add(new Sets(towers,h));
             bool inClosed = false;
            //********************************************************************************


            //My Production System:
            //1)Move A to C
            //2)Move A to B            
            //3)Move B to C
            //4)Move B to A
            //5)Move C to B
            //6)Move C to A

            //Production Rules:
            //1)Can only move one disk at a time
            //2)A larger disk(number) may not be above a smaller disk(number)

             while (nextTower[count] != goalState)
             {      
                 if(nextTower[count].SequenceEqual(goalState))
                 {
                     break;
                 }
                 count++;
                 totalCount++;

                 diskA = findDisk(nextTower[count-1], 0);
                 diskB = findDisk(nextTower[count-1], 3);
                 diskC = findDisk(nextTower[count-1], 6);

                 indexA = findIndex(nextTower[count-1], 0);
                 indexB = findIndex(nextTower[count-1], 3);
                 indexC = findIndex(nextTower[count-1], 6);
                 #region Rules
                 if (diskA < diskC || diskC == 0)
                 {
                     if (deadEnd == true)
                     {
                         deadEnd = false;
                     }
                     else
                     {
                         deadEnd = false;                         
                         nextTower[count] = new int[9];
                         Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         zeroIndex = findZero(nextTower[count], 8);
                         tempDisk = nextTower[count][indexA];                         
                         nextTower[count][indexA] = nextTower[count][zeroIndex];
                         nextTower[count][zeroIndex] = tempDisk;

                         isLoop = loopTest(nextTower[count], closed);

                         if (isLoop == false)
                         {
                             //PrevTowers.Enqueue(nextTower[count]);
                             closed.Add(nextTower[count]);

                             continue;
                         }
                         else
                         {
                             Array.Copy(nextTower[count - 1], nextTower[count], 9);    
                         }
                     }
                 }

                 if (diskA < diskB || diskB == 0)
                 {
                     if (deadEnd == true)
                     {
                         deadEnd = false;
                     }
                     else
                     {
                         deadEnd = false;
                         nextTower[count] = new int[9];
                         Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         zeroIndex = findZero(nextTower[count], 5);
                         tempDisk = nextTower[count][indexA];
                         nextTower[count][indexA] = nextTower[count][zeroIndex];
                         nextTower[count][zeroIndex] = tempDisk;

                         isLoop = loopTest(nextTower[count], closed);

                         if (isLoop == false)
                         {
                             //PrevTowers.Enqueue(nextTower[count]);
                             closed.Add(nextTower[count]);

                             continue;
                         }
                         else
                         {
                             Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         }
                     }
                 }
                
                 if (diskB < diskC || diskC == 0)
                 {
                     if (deadEnd == true)
                     {
                         deadEnd = false;
                     }
                     else
                     {
                         deadEnd = false;
                         nextTower[count] = new int[9];
                         Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         zeroIndex = findZero(nextTower[count], 8);
                         tempDisk = nextTower[count][indexB];
                         nextTower[count][indexB] = nextTower[count][zeroIndex];
                         nextTower[count][zeroIndex] = tempDisk;

                         isLoop = loopTest(nextTower[count], closed);

                         if (isLoop == false)
                         {
                             //PrevTowers.Enqueue(nextTower[count]);
                             closed.Add(nextTower[count]);

                             continue;
                         }
                         else
                         {
                             Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         }
                     }
                 }
                 if (diskB < diskA || diskA == 0)
                 {
                     if (deadEnd == true)
                     {
                         deadEnd = false;
                     }
                     else
                     {
                         deadEnd = false;
                         nextTower[count] = new int[9];
                         Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         zeroIndex = findZero(nextTower[count], 2);
                         tempDisk = nextTower[count][indexB];
                         nextTower[count][indexB] = nextTower[count][zeroIndex];
                         nextTower[count][zeroIndex] = tempDisk;

                         isLoop = loopTest(nextTower[count], closed);

                         if (isLoop == false)
                         {
                             //PrevTowers.Enqueue(nextTower[count]);
                             closed.Add(nextTower[count]);

                             continue;
                         }
                         else
                         {
                             Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         }
                     }
                 }
                 if (diskC < diskB || diskB == 0)
                 {
                     if (deadEnd == true)
                     {
                         deadEnd = false;
                     }
                     else
                     {
                         deadEnd = false;
                         nextTower[count] = new int[9];
                         Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         zeroIndex = findZero(nextTower[count], 5);
                         tempDisk = nextTower[count][indexC];
                         nextTower[count][indexC] = nextTower[count][zeroIndex];
                         nextTower[count][zeroIndex] = tempDisk;

                         isLoop = loopTest(nextTower[count], closed);

                         if (isLoop == false)
                         {
                             //PrevTowers.Enqueue(nextTower[count]);
                             closed.Add(nextTower[count]);

                             continue;
                         }
                         else
                         {
                             Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         }
                     }
                         
                 }
                 if (diskC < diskA || diskA == 0)
                 {
                     if (deadEnd == true)
                     {
                         deadEnd = false;
                     }
                     else
                     {
                         deadEnd = false;
                         nextTower[count] = new int[9];
                         Array.Copy(nextTower[count - 1], nextTower[count], 9);
                         zeroIndex = findZero(nextTower[count], 2);
                         tempDisk = nextTower[count][indexC];
                         nextTower[count][indexC] = nextTower[count][zeroIndex];
                         nextTower[count][zeroIndex] = tempDisk;

                         isLoop = loopTest(nextTower[count], closed);

                         if (isLoop == false)
                         {
                             //PrevTowers.Enqueue(nextTower[count]);
                             closed.Add(nextTower[count]);

                             continue;
                         }
                         else
                         {
                             Array.Copy(nextTower[count - 1], nextTower[count], 9);    
                         }
                     }
                 }

                 Array.Copy(nextTower[count - 1], nextTower[count], 9);
                 deadEnd = true;
                 count--;
                 #endregion
             }

            outputFile.Write("Number of Iterations: " + totalCount + " Final State: ");
            foreach (var item in nextTower[count])
            {
                outputFile.Write(item.ToString() + " ");
            }            

            outputFile.WriteLine("");
            outputFile.WriteLine("Where each section of 3 represents a tower (0 0 0) = A (0 0 0) = B (1 2 3) = C");
//********************************HW 8- Heuristic Test**********************************************************************

            while (true)
            {                         
                if(newClosed[totalHcount].Current.SequenceEqual(goalState))
                {
                    break;
                }                
                totalHcount++;
                h = findH(nextPath, goalState);

                diskA = findDisk(nextPath, 0);
                diskB = findDisk(nextPath, 3);
                diskC = findDisk(nextPath, 6);

                indexA = findIndex(nextPath, 0);
                indexB = findIndex(nextPath, 3);
                indexC = findIndex(nextPath, 6);
                
                if (diskA < diskC || diskC == 0)
                {                    
                    possibleState[hcount] = new int[9];
                    Array.Copy(nextPath, possibleState[hcount], 9);
                    zeroIndex = findZero(possibleState[hcount], 8);
                    tempDisk = possibleState[hcount][indexA];
                    possibleState[hcount][indexA] = possibleState[hcount][zeroIndex];
                    possibleState[hcount][zeroIndex] = tempDisk;

                    h = findH(possibleState[hcount], goalState);
                    for (int v = 0; v < open.Count; v++)
                    {
                        if (possibleState[hcount].SequenceEqual(open[v].Current))
                        {
                            inClosed = true;
                            break;
                        }
                        else
                        {
                            inClosed = false;
                        }                       

                    }

                    if (inClosed == false)
                    {
                        for (int v = 0; v < newClosed.Count; v++)
                        {
                            if (possibleState[hcount].SequenceEqual(newClosed[v].Current))
                            {
                                inClosed = true;
                                break;
                            }
                            else
                            {
                                inClosed = false;
                            }
                        }
                    }
                    if (inClosed == false)
                    {
                        open.Add(new Sets(possibleState[hcount], h));
                    }
                    hcount++;
                    
                         
                }

                if (diskA < diskB || diskB == 0)
                {                  
                    possibleState[hcount] = new int[9];
                    Array.Copy(nextPath, possibleState[hcount], 9);
                    zeroIndex = findZero(possibleState[hcount], 5);
                    tempDisk = possibleState[hcount][indexA];
                    possibleState[hcount][indexA] = possibleState[hcount][zeroIndex];
                    possibleState[hcount][zeroIndex] = tempDisk;

                    for (int v = 0; v < open.Count; v++)
                    {
                        if (possibleState[hcount].SequenceEqual(open[v].Current))
                        {
                            inClosed = true;
                            break;
                        }
                        else
                        {
                            inClosed = false;
                        }

                    }

                    if (inClosed == false)
                    {
                        for (int v = 0; v < newClosed.Count; v++)
                        {
                            if (possibleState[hcount].SequenceEqual(newClosed[v].Current))
                            {
                                inClosed = true;
                                break;
                            }
                            else
                            {
                                inClosed = false;
                            }
                        }
                    }
                    if (inClosed == false)
                    {
                        open.Add(new Sets(possibleState[hcount], h));
                    }
                    hcount++;
                }

                if (diskB < diskC || diskC == 0)
                {
                       
                    possibleState[hcount] = new int[9];
                    Array.Copy(nextPath, possibleState[hcount], 9);
                    zeroIndex = findZero(possibleState[hcount], 8);
                    tempDisk = possibleState[hcount][indexB];
                    possibleState[hcount][indexB] = possibleState[hcount][zeroIndex];
                    possibleState[hcount][zeroIndex] = tempDisk;

                    h = findH(possibleState[hcount], goalState);
                    for (int v = 0; v < open.Count; v++)
                    {
                        if (possibleState[hcount].SequenceEqual(open[v].Current))
                        {
                            inClosed = true;
                            break;
                        }
                        else
                        {
                            inClosed = false;
                        }

                    }

                    if (inClosed == false)
                    {
                        for (int v = 0; v < newClosed.Count; v++)
                        {
                            if (possibleState[hcount].SequenceEqual(newClosed[v].Current))
                            {
                                inClosed = true;
                                break;
                            }
                            else
                            {
                                inClosed = false;
                            }
                        }
                    }
                    if (inClosed == false)
                    {
                        open.Add(new Sets(possibleState[hcount], h));
                    }
                    hcount++;
                        
                }
                if (diskB < diskA || diskA == 0)
                {                    
                       
                    possibleState[hcount] = new int[9];
                    Array.Copy(nextPath, possibleState[hcount], 9);
                    zeroIndex = findZero(possibleState[hcount], 2);
                    tempDisk = possibleState[hcount][indexB];
                    possibleState[hcount][indexB] = possibleState[hcount][zeroIndex];
                    possibleState[hcount][zeroIndex] = tempDisk;

                    h = findH(possibleState[hcount], goalState);
                    for (int v = 0; v < open.Count; v++)
                    {
                        if (possibleState[hcount].SequenceEqual(open[v].Current))
                        {
                            inClosed = true;
                            break;
                        }
                        else
                        {
                            inClosed = false;
                        }

                    }

                    if (inClosed == false)
                    {
                        for (int v = 0; v < newClosed.Count; v++)
                        {
                            if (possibleState[hcount].SequenceEqual(newClosed[v].Current))
                            {
                                inClosed = true;
                                break;
                            }
                            else
                            {
                                inClosed = false;
                            }
                        }
                    }
                    if (inClosed == false)
                    {
                        open.Add(new Sets(possibleState[hcount], h));
                    }
                    hcount++;
                       
                }
                if (diskC < diskB || diskB == 0)
                {

                    possibleState[hcount] = new int[9];
                    Array.Copy(nextPath, possibleState[hcount], 9);
                    zeroIndex = findZero(possibleState[hcount], 5);
                    tempDisk = possibleState[hcount][indexC];
                    possibleState[hcount][indexC] = possibleState[hcount][zeroIndex];
                    possibleState[hcount][zeroIndex] = tempDisk;

                    h = findH(possibleState[hcount], goalState);
                    for (int v = 0; v < open.Count; v++)
                    {
                        if (possibleState[hcount].SequenceEqual(open[v].Current))
                        {
                            inClosed = true;
                            break;
                        }
                        else
                        {
                            inClosed = false;
                        }

                    }

                    if (inClosed == false)
                    {
                        for (int v = 0; v < newClosed.Count; v++)
                        {
                            if (possibleState[hcount].SequenceEqual(newClosed[v].Current))
                            {
                                inClosed = true;
                                break;
                            }
                            else
                            {
                                inClosed = false;
                            }
                        }
                    }
                    if (inClosed == false)
                    {
                        open.Add(new Sets(possibleState[hcount], h));
                    }
                    hcount++;

                }
                if (diskC < diskA || diskA == 0)
                {
                    possibleState[hcount] = new int[9];
                    Array.Copy(nextPath, possibleState[hcount], 9);
                    zeroIndex = findZero(possibleState[hcount], 2);
                    tempDisk = possibleState[hcount][indexC];
                    possibleState[hcount][indexC] = possibleState[hcount][zeroIndex];
                    possibleState[hcount][zeroIndex] = tempDisk;

                    h = findH(possibleState[hcount], goalState);
                    for (int v = 0; v < open.Count; v++)
                    {
                        if (possibleState[hcount].SequenceEqual(open[v].Current))
                        {
                            inClosed = true;
                            break;
                        }
                        else
                        {
                            inClosed = false;
                        }

                    }

                    if (inClosed == false)
                    {
                        for (int v = 0; v < newClosed.Count; v++)
                        {
                            if (possibleState[hcount].SequenceEqual(newClosed[v].Current))
                            {
                                inClosed = true;
                                break;
                            }
                            else
                            {
                                inClosed = false;
                            }
                        }
                    }
                    if (inClosed == false)
                    {
                        open.Add(new Sets(possibleState[hcount], h));                        
                    }
                    hcount++;
                }

                h = 99;
                int j = 0;
                for (int x = 0; x < open.Count; x++)
                {
                    if (open[x].H < h)
                    {
                        h = open[x].H;
                        j = x;
                    }
                }

                newClosed.Add(new Sets(open[j].Current,h));
                Array.Copy(open[j].Current, nextPath, 9);
                open.RemoveAt(j);              

                outputFile.WriteLine();
                outputFile.WriteLine("h:" + h);
                outputFile.WriteLine("Open: ");
                for (int i = 0; i < open.Count(); i++)
                {
                    outputFile.Write(string.Concat(open[i].Current) + " ");
                }
                outputFile.WriteLine();
                outputFile.WriteLine("Closed: ");
                for (int i = 0; i < newClosed.Count(); i++)
                {
                    outputFile.Write(string.Concat(newClosed[i].Current) + " ");
                }
                outputFile.WriteLine();

            }


            outputFile.Write("Number of Iterations: " + totalHcount + " Final State: ");
            foreach (var item in newClosed[totalHcount].Current)
            {
                outputFile.Write(item.ToString() + " ");
            }
//******************************************************************************************
            outputFile.Close();

        }

        public static int findDisk(int[] array, int index)
        {
            int count = 0;
            for (int i = index; i < array.Length; i++)
            {
                if (count == 3)
                {
                    return array[i - 1];
                }

                if (array[i] != 0)
                {
                    return array[i];
                }
                
                count++; 
            }

            return array[index + count - 1];
        }

        public static int findIndex(int[] array, int index)
        {
            int count = 0;
            for (int i = index; i < array.Length; i++)
            {

                if (count == 3)
                {
                    return i - 1;
                }

                if (array[i] != 0)
                {
                    return i;
                }

                count++;
            }

            return index + count - 1;
        }

        public static int findZero(int[] array, int index)
        {
            for (int i = index; i >= 0; i--)
            {
                if (array[i] == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public static bool loopTest(int[] array, List<int[]> closed)
        {
            for (int i = 0; i < closed.Count; i++)
            {
                if (closed[i].SequenceEqual(array))
                {
                    return true;
                }
            }          

            return false;
        }

        public static int findH(int[] present, int[] goal)
        {
            int h = 0;
            for (int i = 0; i < goal.Length; i++)
            {
                if (present[i] != goal[i])
                {
                    h++;
                }
            }

            return h;
        }
       
    }
}
