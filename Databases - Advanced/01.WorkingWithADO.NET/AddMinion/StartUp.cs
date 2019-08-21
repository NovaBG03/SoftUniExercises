namespace AddMinion
{
    using System;
    using System.Data.SqlClient;

    using VillainNames;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInput = Console.ReadLine().Split();
            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string minionTown = minionInput[3];

            string[] villainInput = Console.ReadLine().Split();
            string villainName = villainInput[1];

            if (!TownExist(minionTown))
            {
                AddTown(minionTown);
            }

            if (!VillainExist(villainName))
            {
                AddVillain(villainName);
            }

            MakeServant(minionName, villainName);
        }

        private static void MakeServant(string minionName, string villainName)
        {
            int minionId = GetId("Minions", "Name", minionName);
            int villainId = GetId("Villains", "Name", villainName);

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"INSERT INTO MinionsVillains VALUES(@MinionId, @VillainId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("MinionId", minionId);
                    command.Parameters.AddWithValue("VillainId", villainId);

                    command.BeginExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
                }
            }
        }

        private static int GetId(string table, string colum, string value)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {table} WHERE [{colum}] = @Value";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter param = new SqlParameter("@Value", value);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;

                    command.Parameters.Add(param);

                    int id = (int)command.ExecuteScalar();

                    return id;
                }
            }
        }

        private static void AddVillain(string villainName)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Villains VALUES(@VillainName, 4)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter townNameParam = new SqlParameter("@VillainName", villainName);
                    townNameParam.SqlDbType = System.Data.SqlDbType.VarChar;

                    command.Parameters.Add(townNameParam);

                    command.BeginExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }
            }
        }

        private static bool VillainExist(string villainName)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Villains WHERE [Name] = @VillainName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter villainNameParam = new SqlParameter("@VillainName", villainName);
                    villainNameParam.SqlDbType = System.Data.SqlDbType.VarChar;

                    command.Parameters.Add(villainNameParam);

                    var result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void AddTown(string townName)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Towns VALUES(@TownName, NULL)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter townNameParam = new SqlParameter("@TownName", townName);
                    townNameParam.SqlDbType = System.Data.SqlDbType.VarChar;

                    command.Parameters.Add(townNameParam);

                    command.BeginExecuteNonQuery();
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
            }
        }

        private static bool TownExist(string townName)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Towns WHERE [Name] = @TownName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter townNameParam = new SqlParameter("@TownName", townName);
                    townNameParam.SqlDbType = System.Data.SqlDbType.VarChar;

                    command.Parameters.Add(townNameParam);

                    var result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
