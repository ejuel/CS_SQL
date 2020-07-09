using System;

//ToDo: Create base class for other projects to inherit from and use to create SQL connections and queries
namespace ZkSql
{
    internal class ZkSql
    {
        private readonly int statusMissingParameters = 1;
        private static void Main(string[] args)
        {
            Console.WriteLine($"Hello From SQL Program!\n{Environment.StackTrace}");

            ZkSql objSql = new ZkSql();
            int status = 0;
            string connectionString = objSql.GenerateConnectionString(ref status);
            Console.WriteLine("the connection string is '{0}'", connectionString);

        }
        public string GenerateConnectionString(ref int pStatus, string pServerAddress = "", string pDataBase = "", string pUsername = "", string pPassword = "")
        {
            if (string.IsNullOrEmpty(pServerAddress) || string.IsNullOrEmpty(pDataBase) || string.IsNullOrEmpty(pUsername) || string.IsNullOrEmpty(pPassword))
            {
                pStatus = statusMissingParameters;
                return "Error: Required parameter(s) are missing or blank";
            }
            Console.WriteLine("Generating connection string from input parameters.");
            return $"Server = {pServerAddress}; Database = {pDataBase}; User Id = {pUsername}; Password = {pPassword};";
        }
        public string ManualConnectionString(ref int pStatus)
        {
            string myServerAddress = "";
            Console.Write("Please enter the server address ('.' for local server, or 'example.com, [port]' setting port if not 1433): ");
            while (myServerAddress == "")
            {
                myServerAddress = Console.ReadLine();
            }

            string myDataBase = "";
            Console.Write("Please enter the database name: ");
            while (myDataBase == "")
            {
                myDataBase = Console.ReadLine();
            }

            string myUsername = "";
            Console.Write("Please enter the user name: ");
            while (myUsername == "")
            {
                myUsername = Console.ReadLine();
            }

            string myPassword = "";
            Console.Write("Please enter the password: ");
            while (myPassword == "")
            {
                myPassword = Console.ReadLine();
            }
            Console.Clear();

            return GenerateConnectionString(ref pStatus, myServerAddress, myDataBase, myUsername, myPassword);
        }
        public void SetData(string pLog)
        {
            //ToDo: Create example query that prevents SQL injection when using parameters.
            Console.WriteLine("Placeholder");
            string commandText = "UPDATE zk.tblLog SET Demographics = @demographics "
                               + "WHERE CustomerID = @ID;";
            /*
            using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = customerID;
            
                // Use AddWithValue to assign Demographics. 
                // SQL Server will implicitly convert strings into XML.
                command.Parameters.AddWithValue("@demographics", demoXml);
            
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            */
        }
    }
}
