using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sendedMessages = new Dictionary<string, int>();
            Dictionary<string, int> recievedMessages = new Dictionary<string, int>();

            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split('=');
                string cmdType = cmdArgs[0];
                if (cmdType == "Add")
                {
                    string username = cmdArgs[1];
                    int sent = int.Parse(cmdArgs[2]);
                    int recieved = int.Parse(cmdArgs[3]);

                    if (!sendedMessages.ContainsKey(username))
                    {
                        sendedMessages.Add(username, sent);
                        recievedMessages.Add(username, recieved);
                    }

                }
                else if (cmdType == "Message")
                {
                    string sender = cmdArgs[1];
                    string reciever = cmdArgs[2];

                    if (sendedMessages.ContainsKey(sender) 
                        && recievedMessages.ContainsKey(reciever))
                    {
                        sendedMessages[sender]++;
                        recievedMessages[reciever]++;
                        int senderTotalMessages = sendedMessages[sender] + recievedMessages[sender];

                        if (senderTotalMessages>=capacity)
                        {
                            sendedMessages.Remove(sender);
                            recievedMessages.Remove(sender);

                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        int recieverTotalMessages = sendedMessages[reciever] + recievedMessages[reciever];

                        if (recieverTotalMessages>=capacity)
                        {
                            sendedMessages.Remove(reciever);
                            recievedMessages.Remove(reciever);
                            Console.WriteLine($"{reciever} reached the capacity!");
                        }
                    }

                }
                else if (cmdType=="Empty")
                {
                    string username = cmdArgs[1];
                    if (username=="All")
                    {
                        sendedMessages.Clear();
                        recievedMessages.Clear();
                    }
                    else
                    {
                        if (sendedMessages.ContainsKey(username))
                        {
                            sendedMessages.Remove(username);
                            recievedMessages.Remove(username);
                        }
                        
                    }            
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {sendedMessages.Count}");

            recievedMessages = recievedMessages.OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in recievedMessages)
            {
                string username = kvp.Key;
                int totalMessages = kvp.Value + sendedMessages[username];

                Console.WriteLine($"{username} - {totalMessages}");
            }
        }
    }
}
