﻿using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d*)!(\d+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            Console.WriteLine("Bought furniture:");

            double sum = 0;

            while (input != "Purchase")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string name2 = match.Groups[1].ToString();

                    Console.WriteLine(name, name2);

                    sum += double.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
