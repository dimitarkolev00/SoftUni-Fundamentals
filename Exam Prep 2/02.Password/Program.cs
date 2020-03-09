using System;
using System.Text.RegularExpressions;

namespace P02.Passwordd
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)$";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string numbers=match.Groups[2].Value;
                    string lower=match.Groups[3].Value;
                    string upper=match.Groups[4].Value;
                    string symbols=match.Groups[5].Value;
                    string encryptedPass = string.Concat(numbers,lower,upper,symbols);
                    Console.WriteLine($"Password: {encryptedPass}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }

            }

        }
    }
}
