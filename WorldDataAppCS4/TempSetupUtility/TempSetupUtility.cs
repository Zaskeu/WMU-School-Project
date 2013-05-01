using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace TempSetupUtility
{
    class TempSetupUtility
    {
        
        static void Main(string[] args)
        {
            StreamReader inputFile;
            short M;
            short rootPtr;
            short N;          
                        
            string[] fileNameSuffix = {"1","2","3"};

            StreamWriter logSession = new StreamWriter("./../../../LogSession.txt");
            for (int i = 0; i < fileNameSuffix.Length; i++)
            {               

                inputFile = new StreamReader("./../../../" + "CodeIndex" + fileNameSuffix[i] + ".txt");
                BinaryWriter binFile = new BinaryWriter(new FileStream("./../../../CodeIndex" + fileNameSuffix[i] + ".bin", 
                    FileMode.Create, FileAccess.ReadWrite));                

                string[] line = inputFile.ReadLine().Split(' ');
                
                M = Convert.ToInt16(line[0]);
                rootPtr = Convert.ToInt16(line[1]);
                N = Convert.ToInt16(line[2]);
                
                binFile.Write(M);
                binFile.Write(rootPtr);
                binFile.Write(N);

                logSession.WriteLine("==============");
                logSession.WriteLine("CodeIndex" + fileNameSuffix[i].ToString() + ".bin" + "    " + "M is" + M.ToString() +
                ",     " + "rootPtr is " + rootPtr.ToString() + ",      " + "N is " + N.ToString());
                logSession.WriteLine("----" + M.ToString() + " TP's----" + " " + "----" + (M - 1) + " KV's----" + "--" + (M - 1) + "DRP's--");

                while (!inputFile.EndOfStream)
                {                    
                   line = inputFile.ReadLine().Split(' ');
                    

                    for (int v = 0; v < M-1; v++)
                    {
                         binFile.Write(Convert.ToInt16(line[(v) * 3]));
                         binFile.Write(line[(v * 3) + 1].ToCharArray());
                         binFile.Write(Convert.ToInt16(line[(v * 3) + 2]));                        
                    }
                   binFile.Write(Convert.ToInt16(line[(3 * (M - 1))]));

                   for (int z = 0; z < M; z++)
                   {
                       logSession.Write("{0,2:-1} ",
                           line[(z) * 3]);
                   }                    
                   for (int z = 0; z < M-1; z++)
                   {
                       logSession.Write(line[(z * 3) + 1] + " ");
                   }
                   for (int z = 0; z < M-1; z++)
                   {
                       logSession.Write("{0,2:-1} ",
                           line[(z * 3) + 2]);
                   }
                   logSession.WriteLine();

                }             

              

                
                    
                
                
                binFile.Close();
                
            }

            


        }
    }
}
