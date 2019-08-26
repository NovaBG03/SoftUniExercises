namespace PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    using VillainNames;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<string> minionNames = GetMinionNames();

            for (int i = 0; i < minionNames.Count/2; i++)
            {
                Console.WriteLine(minionNames[i]);

                if (i > minionNames.Count / 2 - 1)
                {
                    break;
                }

                Console.WriteLine(minionNames[minionNames.Count - i - 1]);
            }
        }

        private static IList<string> GetMinionNames()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                IList<string> minionNames = new List<string>();

                connection.Open();

                string query = @"SELECT [Name] FROM Minions ORDER BY Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string minionName = (string)reader[0];

                            minionNames.Add(minionName);
                        }
                    }
                }

                return minionNames;
            }
        }
    }
}
