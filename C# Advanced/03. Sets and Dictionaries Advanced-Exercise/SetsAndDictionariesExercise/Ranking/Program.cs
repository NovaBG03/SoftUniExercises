using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        private static Dictionary<string, string> contests;
        private static Dictionary<string, Dictionary<string, int>> users;

        static void Main(string[] args)
        {
            users = new Dictionary<string, Dictionary<string, int>>();
            contests = new Dictionary<string, string>();

            AddContests();

            AddUsers();

            PrintUsers();
        }

        private static void PrintUsers()
        {
            KeyValuePair<string, int> bestUser = GetBestUser();

            Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value} points.");
            Console.WriteLine("Ranking:");

            foreach (var userKvp in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(userKvp.Key);

                foreach (var contestKvp in userKvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestKvp.Key} -> {contestKvp.Value}");
                }
            }
        }

        private static KeyValuePair<string, int> GetBestUser()
        {
            KeyValuePair<string, int> bestUser = new KeyValuePair<string, int>("", -1);

            foreach (var userKvp in users.OrderBy(x => x.Key))
            {
                int currentUserPoints = 0;

                foreach (var contestKvp in userKvp.Value)
                {
                    currentUserPoints += contestKvp.Value;
                }

                if (bestUser.Value < currentUserPoints)
                {
                    bestUser = new KeyValuePair<string, int>(userKvp.Key, currentUserPoints);
                }
            }

            return bestUser;
        }

        private static void AddUsers()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    return;
                }

                string[] inputArg = input.Split("=>");
                string contest = inputArg[0];
                string password = inputArg[1];
                string username = inputArg[2];
                int points = int.Parse(inputArg[3]);

                if (contests.ContainsKey(password) && contests[password] == contest)
                {
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                    }

                    if (!users[username].ContainsKey(contest))
                    {
                        users[username][contest] = points;
                    }
                    else if (users[username][contest] < points)
                    {
                        users[username][contest] = points;
                    }
                }
            }
        }

        private static void AddContests()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    return;
                }

                string[] inputArg = input.Split(':');
                string contest = inputArg[0];
                string password = inputArg[1];

                if (!contests.ContainsKey(password))
                {
                    contests[password] = contest;
                }
            }
        }
    }
}
