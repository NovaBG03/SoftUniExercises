namespace RemoveVillain
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    using VillainNames;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            string villainName = GetVillainName(villainId);

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            int minionsCount = ReleaseMinions(villainId);
            DeleteVillain(villainId);

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{minionsCount} minions were released.");

        }

        private static int ReleaseMinions(int villainId)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();


                string query = @"DELETE FROM MinionsVillains WHERE VillainId = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", villainId);

                    return command.ExecuteNonQuery();
                }
            }
        }

        private static void DeleteVillain(int villainId)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();


                string query = @"DELETE FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", villainId);

                    command.ExecuteNonQuery();
                }
            }
        }

        private static string GetVillainName(int villainId)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT [Name] FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", villainId);

                    string villainName = (string)command.ExecuteScalar();

                    return villainName;
                }
            }
        }
    }
}
