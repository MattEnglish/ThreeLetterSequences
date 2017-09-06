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
            String theText = File.ReadAllText("SampleText.txt");
            Dictionary<string, int> dict = TLS(theText);
            string a = "pre";
            int count = dict[a];
            Console.WriteLine(count);
        }

        static Dictionary<string, int> TLS(string theText)
        {

            Dictionary<string, int> TLS = new Dictionary<string, int>();
            string pattern = @"(\w(?=(\w)(\w)))";

            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = Regex.Matches(theText, pattern);

            foreach (Match match in matches)
            {
                string tLS ="";
                for (int i = 1; i < match.Groups.Count+1; i++)
                {
                    tLS += match.Groups[i].ToString();
                }               
                tLS = tLS.ToLower();

                if (TLS.ContainsKey(tLS))
                {
                    TLS[tLS]++;
                }
                else
                {
                    TLS.Add(tLS, 1);
                }
            }
            return TLS;
        }



        static Dictionary<string, int> TLSold(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string pattern = @"(\w(?=\w\w))";
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = Regex.Matches(s, pattern);

            foreach (Match match in matches)
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
