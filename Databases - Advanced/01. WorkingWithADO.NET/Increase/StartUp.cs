namespace IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    using VillainNames;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionsIds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            UpdateMinions(minionsIds);

            PrintMinionsInfo(minionsIds);
        }

        private static void PrintMinionsInfo(int[] minionsIds)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                foreach (var id in minionsIds)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = (string)reader[0];
                                int age = (int)reader[1];

                                Console.WriteLine($"{name} – {age} years old");
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateMinions(int[] minionsIds)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"EXEC usp_GetOlder @Id";
                foreach (var id in minionsIds)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}