using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ThreeLetterSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = System.IO.File.ReadAllText("SampleText.txt");
            int traCount = traCounter(s);
            Console.WriteLine(traCount);

            
        }

        static int traCounter(string s)
        {
            int counter = 0;
            Regex rx = new Regex("(tra)");
            MatchCollection matches = rx.Matches(s);
            return matches.Count;
            
        }
        

    }
}
