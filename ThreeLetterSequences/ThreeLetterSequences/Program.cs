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
            Dictionary<string
                , int> dict = TLS(s);
            string a = "pre";
            int count = dict[a];
            Console.WriteLine(count);

            
        }

        static int traCounter(string s)
        {
            
            Regex rx = new Regex("(t)",RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(s);
            return matches.Count;
            
        }
        
        static Dictionary<string,int> TLS(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Regex rx = new Regex(@"(\w(?=\w\w))", RegexOptions.IgnoreCase);
            
            MatchCollection matches = rx.Matches(s);
            foreach(Match match in matches)
            {
                string tLS = s.Substring(match.Index, 3);
                
                tLS = tLS.ToLower();
                if (dict.ContainsKey(tLS))
                {
                    dict[tLS]++;
                }
                else
                {
                    dict.Add(tLS, 1);
                }
                
                
            }
            return dict;

        }

    }
}
