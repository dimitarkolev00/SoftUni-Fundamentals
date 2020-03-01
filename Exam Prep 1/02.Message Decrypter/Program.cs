using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^([$%])([A-Z][a-z]{2,})\1\:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    string message = String.Empty;
                    for (int j = 3; j < match.Groups.Count; j++)
                    {
                        int val = int.Parse(match.Groups[j].Value);
                        message += (char)(val);
                        
                    }
                    Console.WriteLine($"{tag}: {message}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
