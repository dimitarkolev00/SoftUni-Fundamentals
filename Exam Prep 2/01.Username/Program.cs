using System;
using System.Linq;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] cmdArgs = command.Split();
                string cmdType = cmdArgs[0];

                if (cmdType == "Case")
                {
                    string caseComand = cmdArgs[1];
                    if (caseComand == "lower")
                    {
                        username = username.ToLower();
                    }
                    else if (caseComand == "upper")
                    {
                        username = username.ToUpper();
                    }
                    Console.WriteLine(username);

                }
                else if (cmdType == "Reverse")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int end = int.Parse(cmdArgs[2]);
                    bool ifIsNotValidStartIndex = start < 0 || start >= username.Length;
                    bool ifIsNotValidEndIndex = end < 0 || end >= username.Length;

                    if (ifIsNotValidEndIndex || ifIsNotValidStartIndex)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    int length = end - start + 1;
                    string subStr = username.Substring(start, length);
                    char[] chars = subStr.Reverse().ToArray();
                    Console.WriteLine(string.Join("", chars));


                }
                else if (cmdType == "Cut")
                {
                    string subStr = cmdArgs[1];
                    if (username.Contains(subStr))
                    {
                        username = username.Replace(subStr, "");
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {subStr}.");
                    }
                }
                else if (cmdType == "Replace")
                {
                    char replace = char.Parse(cmdArgs[1]);
                    username = username.Replace(replace, '*');
                    Console.WriteLine(username);

                }
                else if (cmdType == "Check")
                {
                    string mustContain = cmdArgs[1];
                    if (username.Contains(mustContain))
                    {
                        Console.WriteLine("Valid");
                    }
                    else if (!username.Contains(mustContain))
                    {
                        Console.WriteLine($"Your username must contain {mustContain}.");
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
