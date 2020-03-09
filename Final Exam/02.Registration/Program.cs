using System;
using System.Text.RegularExpressions;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([U$]+)([A-Z][a-z]{2,})\1([P@$]+)([a-z]{5,}[\d]+)(\3)";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            int successCount = 0; 
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                
                if (match.Success)
                {
                    string username = match.Groups[2].Value;
                    string password = match.Groups[4].Value;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                    successCount++;
                    
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successCount}");
        }
    }
}
