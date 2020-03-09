using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> likes = new Dictionary<string, int>();
            Dictionary<string, int> comments = new Dictionary<string, int>();

            string command = Console.ReadLine();
            while (command != "Log out")
            {
                string[] cmdAgrs = command.Split(": ");
                string cmdType = cmdAgrs[0];
                string username = cmdAgrs[1];

                if (cmdType == "New follower")
                {
                    if (!likes.ContainsKey(username))
                    {
                        likes.Add(username, 0);
                        comments.Add(username, 0);
                    }
                }
                else if (cmdType == "Like")
                {
                    int count = int.Parse(cmdAgrs[2]);
                    if (!likes.ContainsKey(username))
                    {
                        likes.Add(username, count);
                        comments.Add(username, 0);

                    }
                    else
                    {
                        likes[username] += count;
                    }
                    

                }
                else if (cmdType == "Comment")
                {
                    if (!comments.ContainsKey(username))
                    {
                        comments.Add(username, 1);
                        likes.Add(username, 0);

                    }
                    else
                    {
                        comments[username] += 1;
                    }
                   
                }
                else if (cmdType == "Blocked")
                {
                    if (!likes.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        likes.Remove(username);
                        comments.Remove(username);
                    }

                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{likes.Count} followers");
            foreach (KeyValuePair<string, int> kvpLikes in likes.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                string username = kvpLikes.Key;
                int coutLikes = kvpLikes.Value;
                int countComments = comments[username];
                Console.WriteLine($"{username}: {countComments + coutLikes}");
            }
        }
    }
}
