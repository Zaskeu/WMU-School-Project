//Mike Reisterer
//5820 AI
//Class: Ktree.cs
//What it does: Declares input and goal states, default location of 0(empty place), as well as having the findH method, it also has the 
//direction methods used for traversing
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkTtree
{
    class Ktree
    {
        public int[,] inputState = new int[3, 3]{{2,1,7},{8,6,0},{3,4,5}};   //2 8 3  <-Initial State
                                                                             //1 6 4 
                                                                             //7 0 5

        public int[,] goalState = new int[3, 3]{{1,8,7},{2,0,6},{3,4,5}};    //1 2 3   <- Goal State
                                                                             //8 0 4
                                                                             //7 6 5
        public int emPtrX = 1;//the default location of the 0 at the x axis
        public int emPtrY = 2;//the default location of the 0 at the y axis
        public int h; //Hueristic

        public Ktree() { } //Empty constructor
        public Ktree(int emPtrX, int emptrY, int h) //Give variables values
        {
            this.emPtrX = emPtrX;
            this.emPtrY = emptrY;
            this.h = h;
        }

        public Ktree Clone() //Credit to Brandon Feldkamp for showing me this
        {
            Ktree temp = new Ktree(emPtrX, emPtrY, h);
            Array.Copy(inputState, temp.inputState, inputState.Length);
            return temp;
        }

        



//******************HUERISTIC FINDER*********************************************************************************
        public int findH(int x)//finds what H is
        {         
            
            int mmCount = 0;
            int distance = 0;
            //Checks every input state, if it is a mismatch, it adds 1 to mmCount(mismatch count) and then finds the distance to correct it
            if (inputState[0, 0] != 1)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(0 - (i + j));
                        }
                    }
            }
            if (inputState[1, 0] != 2)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(1 - (i + j));
                        }
                    }
            }
            if (inputState[2, 0] != 3)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(2 - (i + j));
                        }
                    }
            }
            if (inputState[2, 1] != 4)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(3 - (i + j));
                        }
                    }
            }
            if (inputState[2, 2] != 5)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(4 - (i + j));
                        }
                    }
            }
            if (inputState[1, 2] != 6)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(3 - (i + j));
                        }
                    }
            }
            if (inputState[0, 2] != 7)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(2 - (i + j));
                        }
                    }
            }
            if (inputState[0, 1] != 8)
            {
                mmCount++;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (goalState[i, j] == 1)
                        {
                            distance += Math.Abs(1 - (i + j));
                        }
                    }
            }
            if (inputState[1, 1] != 0)
            {
                mmCount++;              
            }

            switch (x)//Which number are we on? 1 2 or 3, H= 0, count or distance
            {               
                case 0:
                    h = mmCount; //Used for random
                    break;

                case 1:
                    h = mmCount; //Base on input do we pick count?
                    break;

                case 2:
                    h = distance; //Or distance?
                    break;
            }

            return h;
            
        }
//****************MOVEMENT METHODS*************************************************************************************
        //Movement uses empty pointers declared above (Which is set to 0s default location) and uses them to move around
        public void up()
        {
            inputState[emPtrX, emPtrY] = inputState[emPtrX, emPtrY - 1];
            emPtrY--;
            inputState[emPtrX, emPtrY] = 0;
        }

        public void down()
        {
            inputState[emPtrX, emPtrY] = inputState[emPtrX, emPtrY + 1];
            emPtrY++;
            inputState[emPtrX, emPtrY] = 0;
        }

        public void left()
        {
            inputState[emPtrX, emPtrY] = inputState[emPtrX - 1, emPtrY];
            emPtrX--;
            inputState[emPtrX, emPtrY] = 0;
        }

        public void right()
        {
            inputState[emPtrX, emPtrY] = inputState[emPtrX + 1, emPtrY];
            emPtrX++;
            inputState[emPtrX, emPtrY] = 0;
        }
    }
}
