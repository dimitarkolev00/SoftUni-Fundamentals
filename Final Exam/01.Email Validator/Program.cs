using System;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Complete")
            {
                string[] cmdArgs = command.Split();
                string cmdType = cmdArgs[0];
                //string cmdType2 = cmdArgs[1];

                if (cmdType == "Make")
                {
                    if (cmdArgs[1] == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }

                }

                else if (cmdType == "GetDomain")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string result = email.Substring(email.Length - count, count);
                    Console.WriteLine(result);

                }
                else if (cmdType == "GetUsername")
                {
                    if (!email.Contains('@'))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        int charIndex = email.IndexOf('@');

                        string result = email.Substring(0, charIndex);
                        Console.WriteLine(result);
                    }
                }
                else if (cmdType == "Replace")
                {
                    char ch = char.Parse(cmdArgs[1]);
                    email = email.Replace(ch, '-');
                    Console.WriteLine(email);
                }
                else if (cmdType == "Encrypt")
                {
                    foreach (char ch in email)
                    {
                        int result = (char)(ch);
                        Console.Write($"{result} ");
                    }
                }


                command = Console.ReadLine();
            }
        }
    }
}
