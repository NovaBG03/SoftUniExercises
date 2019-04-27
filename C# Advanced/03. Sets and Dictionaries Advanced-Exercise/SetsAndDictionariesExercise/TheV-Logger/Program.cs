using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        private static Dictionary<string, SortedSet<string>> vloggerFollowers;
        private static Dictionary<string, SortedSet<string>> vloggerFollowings;

        static void Main(string[] args)
        {
            //vloger ---> list imena na followers
            //vloger ---> list imena na following

            vloggerFollowers = new Dictionary<string, SortedSet<string>>();
            vloggerFollowings = new Dictionary<string, SortedSet<string>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] inputArg = input.Split();
                string vloggerName = inputArg[0];
                string command = inputArg[1]?.ToLower();

                switch (command)
                {
                    case "joined":
                        AddVlogger(vloggerName);
                        break;
                    case "followed":
                        string followedVloggerName = inputArg[2];
                        FollowVlogger(vloggerName, followedVloggerName);
                        break;
                    default:
                        break;
                }
            }


            PrintStatistics();
        }

        private static void PrintStatistics()
        {
            Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Keys.Count} vloggers in its logs.");

            vloggerFollowers = vloggerFollowers.OrderByDescending(x => x.Value.Count)
                .ThenBy(y => vloggerFollowings[y.Key].Count)
                .ToDictionary(y => y.Key, x => x.Value);

            int i = 1;
            foreach (var kvp in vloggerFollowers)
            {
                Console.WriteLine($"{i}. {kvp.Key} : {kvp.Value.Count} followers, {vloggerFollowings[kvp.Key].Count} following");

                if (i == 1)
                {
                    foreach (var name in kvp.Value)
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }

                i++;
            }
        }

        private static void FollowVlogger(string vloggerName, string followedVloggerName)
        {
            if (vloggerFollowers.ContainsKey(vloggerName)
                && vloggerFollowers.ContainsKey(followedVloggerName)
                && vloggerName != followedVloggerName)
            {
                vloggerFollowers[followedVloggerName].Add(vloggerName);
                vloggerFollowings[vloggerName].Add(followedVloggerName);
            }
        }

        private static void AddVlogger(string vloggerName)
        {
            if (!vloggerFollowers.ContainsKey(vloggerName))
            {
                vloggerFollowers[vloggerName] = new SortedSet<string>();
                vloggerFollowings[vloggerName] = new SortedSet<string>();
            }
        }
    }
}
