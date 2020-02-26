using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            int coun = 0;
            string command = string.Empty;
            string name = string.Empty;

            List<string> guests = new List<string>();

            while (coun < numberOfCommands)
            {
                command = Console.ReadLine();
                string[] part = command.Split();
                name = part[0];
                if (part[1] == "is" && part[2] == "going!")
                {
                    if (!guests.Contains(name))
                    {
                        guests.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
                if (part[2]=="not")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);

                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                coun++;
            }
            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
