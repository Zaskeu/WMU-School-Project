using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WorldDataAppCS4
{
     public class CodeIndex
    {
        BinaryReader binFile;
        short M;
        short RootPtr;
        short N;

        short[] treePtr;
        string[] keyValue;
        short[] DRP;
        public int NodeCount;
        
        public CodeIndex(string x)
        {         
             binFile = new BinaryReader(new FileStream("./../../../CodeIndex" + x + ".bin",
                    FileMode.Open, FileAccess.Read));

             M = binFile.ReadInt16();
             RootPtr = binFile.ReadInt16();
             N = binFile.ReadInt16();

             treePtr = new short[M];
             keyValue = new string[M];
             DRP = new short[M-1];



        }

        private void ReadOneNode(short RRN)
        {
            binFile.BaseStream.Seek(((M - 1) * 3 + (M * 2) + (M - 1) * 2) * (RRN - 1) + 6, SeekOrigin.Begin);  
            for (int v = 0; v < M-1; v++)
                    {
                     treePtr[v] = binFile.ReadInt16();
                     keyValue[v] = new string(binFile.ReadChars(3));
                     DRP[v] = binFile.ReadInt16();                        
                    }
            treePtr[M-1] = binFile.ReadInt16();
            keyValue[M - 1] = "]]]";
        }

        private short SearchOneNode(string code, out bool treePtrBool)
        {            
            for (int i = 0; i < M; i++)
            {
                if (string.CompareOrdinal(keyValue[i], code) > 0)
                {
                    treePtrBool = true;
                    return treePtr[i];
                }
                if (string.CompareOrdinal(keyValue[i], code) == 0)
                {
                    treePtrBool = false;
                    return DRP[i];
                }                
                
            }
            treePtrBool = true;
            return -1;

        }

        public short QueryByCode(string qcode)
        {
            NodeCount = 1;
            bool treePtrBool;
            short savedValue;
            ReadOneNode(RootPtr);
            savedValue = SearchOneNode(qcode, out treePtrBool);
            while (treePtrBool != false)
            {
                NodeCount++;
                if (savedValue == -1)
                {
                    //ERROR - no matching code in index
                    break;
                }
                else
                {
                    ReadOneNode(savedValue);
                    savedValue = SearchOneNode(qcode, out treePtrBool);
                }
            }
            return savedValue;    

        }

        public void FinishUp()
        {
            binFile.Close();
        }



    }
}
