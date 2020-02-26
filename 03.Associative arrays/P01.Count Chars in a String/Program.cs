using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurances = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (letter != ' ')
                {
                    if (!occurances.ContainsKey(letter))
                    {
                        occurances.Add(letter, 0);
                    }
                    occurances[letter]++;
                }

            }
            foreach (var c in occurances)
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }
        }
    }
}
