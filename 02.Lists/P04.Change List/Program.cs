using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split(' ');
                string cmd = tokens[0];
                int element = int.Parse(tokens[1]);
                if (cmd == "Delete")
                {

                    numbers.RemoveAll(el => el == element);

                }
                else if (cmd == "Insert")
                {
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
