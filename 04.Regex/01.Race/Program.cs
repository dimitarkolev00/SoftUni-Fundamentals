using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"[A-Za-z]+";
            Regex nameRegex = new Regex(namePattern);

            string digitPattern = @"\d";
            Regex digitRegex = new Regex(digitPattern);

            List<string> participants = Regex.Split(Console.ReadLine(), ",\\s+").ToList();

            Dictionary<string, int> participantDict = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection charsCollection = nameRegex.Matches(input);
                string name = string.Join("", charsCollection);

                if (participants.Contains(name))
                {
                    MatchCollection digitCollection = digitRegex.Matches(input);
                    int distance = 0;

                    foreach (Match match in digitCollection)
                    {
                        int digit = int.Parse(match.Value);
                        distance += digit;
                    }

                    if (!participantDict.ContainsKey(name))
                    {
                        participantDict.Add(name, 0);
                    }
                    participantDict[name] += distance;
                }

                input = Console.ReadLine();
            }

            participantDict = participantDict
                .OrderByDescending(p => p.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            int counter = 1;

            foreach (KeyValuePair<string, int> kvp in participantDict)
            {
                string text = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";

                Console.WriteLine($"{counter++}{text} place: {kvp.Key}");
                if (counter == 4)
                {
                    break;
                }
            }
        }
    }
}
