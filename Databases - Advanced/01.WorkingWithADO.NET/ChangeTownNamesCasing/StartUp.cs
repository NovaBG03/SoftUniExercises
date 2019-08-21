namespace ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    using VillainNames;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();

            IDictionary<int, string> dictionary = GetTowns(country);

            foreach (var kvp in dictionary)
            {
                int townId = kvp.Key;
                string townName = kvp.Value.ToUpper();

                UpdateTown(townId, townName);
            }

            dictionary = GetTowns(country);

            if (dictionary.Count == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{dictionary.Count} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", dictionary.Values)}]");
            }
        }

        private static void UpdateTown(int townId, string townName)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateQuery = @"UPDATE Towns
                                       SET Name = @TownName
                                       WHERE Id = @TownId";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    SqlParameter TownNameParam = new SqlParameter("@TownName", townName);
                    TownNameParam.SqlDbType = System.Data.SqlDbType.VarChar;
                    updateCommand.Parameters.Add(TownNameParam);

                    SqlParameter TownIdParam = new SqlParameter("@TownId", townId);
                    TownIdParam.SqlDbType = System.Data.SqlDbType.Int;
                    updateCommand.Parameters.Add(TownIdParam);

                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        private static IDictionary<int, string> GetTowns(string country)
        {
            IDictionary<int, string> dictionary = new Dictionary<int, string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string selectQuery = @"SELECT 
                                       	 t.[Id]
                                       	,t.[Name]
                                       FROM Countries AS c
                                       JOIN Towns AS t
                                       	ON t.CountryCode = c.Id
                                       WHERE c.[Name] = @CountryName";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    SqlParameter param = new SqlParameter("@CountryName", country);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;

                    selectCommand.Parameters.Add(param);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int townId = (int)reader[0];
                            string townName = (string)reader[1];

                            dictionary.Add(townId, townName);
                        }
                    }
                }
            }

            return dictionary;
        }
    }
}
