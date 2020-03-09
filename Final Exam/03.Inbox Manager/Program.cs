using System;
using System.Collections.Generic;
using System.Linq;

namespace P03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> username = new Dictionary<string, string>();
            Dictionary<string, List<string>> sentEmails = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split("->");
                string cmdType = cmdArgs[0];
                string usernameCheck = cmdArgs[1];

                if (cmdType == "Add")
                {

                    if (!sentEmails.ContainsKey(usernameCheck))
                    {
                        sentEmails.Add(usernameCheck, new List<string>());
                       
                    }
                    else
                    {
                        Console.WriteLine($"{usernameCheck} is already registered");
                    }


                }
                else if (cmdType == "Send")
                {
                    string email = cmdArgs[2];
                    sentEmails[usernameCheck].Add(email);
                }
                else if (cmdType == "Delete")
                {
                    if (!sentEmails.ContainsKey(usernameCheck))
                    {
                        Console.WriteLine($"{ usernameCheck} not found!");
                    }
                    else
                    {
                        sentEmails.Remove(usernameCheck);
                      
                    }

                }

                command = Console.ReadLine();

            }
            Console.WriteLine($"Users count: {sentEmails.Count}");

            
            foreach (var kvp in sentEmails.OrderByDescending(u=>u.Value.Count).ThenBy(u=>u.Key))
            {
                
                Console.WriteLine($"{kvp.Key}");
                foreach (var emails in kvp.Value)
                {
                    Console.WriteLine($" - {emails}");
                }

            }
        }
    }
}
