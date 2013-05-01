using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WorldDataAppCS4;

namespace TempUserApp
{
    class TempUserApp
    {       
       
        static void Main(string[] args)
        {           
            StreamReader inputFile;
            StreamReader tranInputFile;         
            
            char[] code = new char[3];           
            string tranCode;
            string tCode;
            
            string[] fileNameSuffix = { "1", "2", "3" };

            StreamWriter logSession = new StreamWriter("./../../../LogSession.txt",true);
            for (int i = 0; i < fileNameSuffix.Length; i++)
            {

                inputFile = new StreamReader("./../../../" + "MainData" + fileNameSuffix[i] + ".txt");
                tranInputFile = new StreamReader("./../../../" + "TransData" + fileNameSuffix[i] + ".txt");                
                CodeIndex index = new CodeIndex(fileNameSuffix[i]);                
                logSession.WriteLine("==============");
                logSession.WriteLine("PROCESSING TransData " + fileNameSuffix[i].ToString());
                while (!tranInputFile.EndOfStream)
                {
                    string[] tranLine = tranInputFile.ReadLine().Split(' ');

                    tranCode = tranLine[0];  //QC
                    tCode = (tranLine[1]);  //***

                    short DRP = index.QueryByCode(tCode);

                    if (DRP == -1)
                    {


                    }
                    else
                    {
                        inputFile.DiscardBufferedData();
                        inputFile.BaseStream.Seek(25 * (DRP - 1), SeekOrigin.Begin);   
                        logSession.WriteLine(tranCode + " " + tCode);
                        logSession.WriteLine(">> "+ inputFile.ReadLine());
                        logSession.WriteLine("[# of nodes read: " + index.NodeCount.ToString() + "]");
                    }
                }

                index.FinishUp();
                inputFile.Close();
                tranInputFile.Close();

            }

            logSession.Close();
        }
        
    }
}
