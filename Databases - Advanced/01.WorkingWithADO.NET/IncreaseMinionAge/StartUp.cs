namespace IncreaseMinionAge
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

            PrintMinionsInfo();
        }

        private static void PrintMinionsInfo()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT Name, Age FROM Minions ORDER BY Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} {age}");
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

                string query = @" UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";
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
