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
            var theText = File.ReadAllText("SampleText.txt");
            var tLSDictionary = GetTLSDictionary(theText);
            PrintFrequencyOfSequence("pre", tLSDictionary);
        }


        static Dictionary<string, int> GetTLSDictionary(string theText)
        {
            var matches = GetThreeLetterSequenceMatches(theText);
            return GetDictionaryFromMatches(matches);
        }

        static MatchCollection GetThreeLetterSequenceMatches(string theText)
        {
            var regularExpression = @"(\w(?=(\w)(\w)))";
            return Regex.Matches(theText, regularExpression);
        }


        static Dictionary<string, int> GetDictionaryFromMatches(MatchCollection matches)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                var matchString = GetLowerCaseStringFromMatch(match);
                addSequenceToDictionary(matchString, dictionary);
            }
            return dictionary;
        }

        static string GetLowerCaseStringFromMatch(Match match)
        {
            var theString = "";
            for (int i = 1; i < match.Groups.Count + 1; i++)
            {
                theString += match.Groups[i].ToString();
            }
            return theString.ToLower();
        }

        static void addSequenceToDictionary(string aThreeLetterSequence, Dictionary<string, int> tLSDictionary)
        {
            if (tLSDictionary.ContainsKey(aThreeLetterSequence))
            {
                tLSDictionary[aThreeLetterSequence]++;
            }
            else
            {
                tLSDictionary.Add(aThreeLetterSequence, 1);
            }
        }


        static void PrintFrequencyOfSequence(string sequence, Dictionary<string, int> dictionary)
        {
            var count = dictionary[sequence];
            Console.WriteLine(count);
        }

    }
}
