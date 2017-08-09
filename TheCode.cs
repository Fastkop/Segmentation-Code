using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int[] indexer = new int[8];
            int i = 0;
            string[,] files = new string[8, 3000];
            Regex r;
            StreamReader sr = new StreamReader("../../Connections.csv");
            StreamReader sr2 = new StreamReader("../../Regexs.txt");
            StreamWriter wr = new StreamWriter("../../NewList.csv",false, Encoding.UTF8);
            string CSVLine = "z", RegexLine = "z";
                while (true) {
                    RegexLine = sr2.ReadLine();
                    if (RegexLine == null)
                        break;
                    r = new Regex(RegexLine,RegexOptions.IgnoreCase);
                    while (true) {
                        CSVLine = sr.ReadLine();
                        if (CSVLine == null)
                            break;
                        if (r.IsMatch(CSVLine))
                            files[i, indexer[i]++] = CSVLine;
                    }
                    i++;
                }
                for ( i = 0; i < 8; i++) {
                    for (int j = 0; j < indexer[i]; j++)
                    {
                            wr.WriteLine("Rank " + (8 - i).ToString()+" , "+files[i, j] + "  Score " + (80 - i * 10).ToString());
                    }
                }
                wr.Flush();
            
        }
    }
}


