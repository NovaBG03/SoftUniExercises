namespace MinionNames
{
    using System;
    using System.Data.SqlClient;

    using VillainNames;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainNameCommandText = @"SELECT v.[Name]
                                   FROM Villains AS v
                                   WHERE v.[Id] = @Id";

                using (SqlCommand villainNameCommand = new SqlCommand(villainNameCommandText, connection))
                {
                    villainNameCommand.Parameters.AddWithValue("@Id", villainId);

                    string villainName = (string)villainNameCommand.ExecuteScalar();

                    if (string.IsNullOrEmpty(villainName) || string.IsNullOrWhiteSpace(villainName))
                    {
                        Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                string selectMinionsCommandText = @"SELECT 
                                                    	 m.[Name]
                                                    	,m.[Age]
                                                    FROM Villains AS v
                                                    JOIN MinionsVillains AS mv
                                                    	ON mv.[VillainId] = v.[Id]
                                                    	AND v.[Id] = @Id
                                                    LEFT JOIN Minions AS m
                                                    	ON m.[Id] = mv.[MinionId]
                                                    ORDER BY m.[Name]";

                using (SqlCommand selectMinionsCommand = new SqlCommand(selectMinionsCommandText, connection))
                {
                    selectMinionsCommand.Parameters.AddWithValue("@Id", villainId);

                    using (SqlDataReader reader = selectMinionsCommand.ExecuteReader())
                    {
                        int colum = 1;
                        while (reader.Read())
                        {
                            string minionName = (string)reader[0];
                            int minionAge = (int)reader[1];

                            Console.WriteLine($"{colum}. {minionName} {minionAge}");
                            colum++;
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}
