﻿namespace VillainNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string cmdText = @"SELECT v.[Name] ,COUNT(mv.[MinionId]) AS MinionsCount
                                 FROM Villains AS v
                                 JOIN MinionsVillains AS mv ON mv.[VillainId] = v.[Id]
                                 GROUP BY v.[Id], v.[Name]
                                 HAVING COUNT(mv.[MinionId]) > 3
                                 ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string villainName = (string)reader[0];
                            int minionsCount = (int)reader[1];

                            Console.WriteLine($"{villainName} - {minionsCount}");
                        }
                    }
                }
            }
        }
    }
}
