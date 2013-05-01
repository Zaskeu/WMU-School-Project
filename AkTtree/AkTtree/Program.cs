//Mike Reisterer
//5820 AI
//Due Date: Feb 21, 2013
//Program 2: AK-T Algorithim 
//Class: Program.cs
//What it does: Taking a default input state(given by our instructor) we use a tree with knowledge to traverse it in 3 different ways.
//First by H(huerstic) = 0, thereby trying it with a tree with no knowledge, then by count of mismatched locations, and lastly by distance

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AkTtree
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int test = 0; //how to flag for first case
            int k = 0; //count
            Ktree present = new Ktree();//Present state              
               
            Random rand = new Random(); //used when h = 0
            string rpath = ""; //Random path
            int x; //Used for counting
            StreamWriter outputFile = new StreamWriter("../../../outputFile.txt");
//**************************RANDOM CASE****************************************************************************
            if (test == 0)
            {
                present.findH(test);

                for (x = 0; present.h > 0; x++)
                {
                    switch (rand.Next(4)) //Which way will I go? (totally random)
                    {
                        case 0:
                            if (present.emPtrY > 0)//To guarantee it does not exceed bounds of array
                            {
                                present.up(); //Moves up
                                rpath += "Up ";                                
                            }
                            break;
                        case 1:
                            if (present.emPtrY < 2)
                            {
                                present.down(); //Moves down
                                rpath += "Down ";                                
                            }
                            break;
                        case 2:
                            if (present.emPtrX > 0)
                            {
                                present.left();
                                rpath += "Left "; //Moves left
                                
                            }
                            break;
                        case 3:
                            if (present.emPtrX < 2)
                            {
                                present.right();
                                rpath += "Right ";  //Moves right                              
                            }
                            break;
                    }
                    present.findH(test); //Finding value of h for the return around the loop
                }
                outputFile.WriteLine("#1: " + rpath + x);                
            }
//******************BOTH DISTANCE AND COUNT INSTANCES***************************************************************
            for (int i = 1; i < 3; i++) //2 h =mmCount, 3 h = distance
            {
              present = new Ktree(); //Present State
              Ktree ktree = new Ktree(); //Used to access findH method
        //*********Movement Objects*******************************
              Ktree up = null;
              Ktree down = null;
              Ktree left = null;
              Ktree right = null;
              
 
              int direction = -1; //up, down, left, or right
              int previous = -1; //previous state

              string path = ""; //Path of states visited

              present.h = ktree.findH(i); //Find H
                
                             
              for (k = 0; present.h > 0; k++)//Make sure distance or mismatch count (mmCount) do no = 0
              {
                  int f = 50; //Used to make sure we find best path

                  if (present.emPtrY > 0 && previous !=2)//Testing Direction and checking bounds on array once more, repeated for each direction
                  {
                      up = present.Clone(); //Used to copy array and store it while changing its actual value
                      up.up(); //Moves up
                      up.findH(i); //Finds H again for if compare ahead
                     

                      if (f > up.h) //Will always be greater here, later on it is possible it would not be
                      {
                          f = up.h;
                          direction = 1;
                          previous = direction;//Sets previous so that we will never go in any direction twice in a row
                      }
                  }
                  if (present.emPtrY < 3 && previous != 1)
                  {
                      down = present.Clone();
                      down.down();
                      down.findH(i);
                      
                      if (f > down.h)
                      {
                          f = down.h;
                          direction = 2;
                          previous = direction;
                      }
                  }
                  if(present.emPtrX > 0 && previous != 4)
                  {
                      left = present.Clone();
                      left.left();
                      left.findH(i);
                      
                      if (f > left.h)
                      {
                          f = left.h;
                          direction = 3;
                          previous = direction;
                      }
                  }
                  if(present.emPtrX < 3 && previous != 3)
                  {
                      right = present.Clone();
                      right.right();
                      right.findH(i);
                     
                      if (f > right.h)
                      {
                          f = right.h;
                          direction = 4;
                          previous = direction;
                      }
                  }
                  

                  switch (direction)//Simple switch to remember and output path to string
                  {
                      case 1:
                          present = up.Clone();
                          path += "Up ";
                          break;
                      case 2:
                          present = down.Clone();
                          path += "Down ";
                          break;
                      case 3:
                          present = left.Clone();
                          path += "Left ";
                          break;
                      case 4:
                          present = right.Clone();
                          path += "Right ";
                          break;                     
                  }
                  Console.WriteLine(path);
              }
              outputFile.WriteLine("#" + (i+1) + ": " + path + k);             
            }            

            outputFile.Close(); //End of program                   
                          
        }



        
    }
}
