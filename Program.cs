using System;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerToDBML
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple args for now.  make them better later.
            var databaseHost = args[0];
            var databaseUser = args[1];
            var databasePassword = args[2];
            var databaseName = args[3];

            // TODO:  connect to db

            var connectionString = "Data Source=" + databaseHost + "; Initial Catalog=" + databaseName + "; User ID=" + databaseUser + "; Password=" + databasePassword;
            using(var con = new SqlConnection(connectionString)){
                using(var cmd = new SqlCommand()){
                    cmd.connection = con;
                    //cmd.commandType="I forget - look it up when I get home";
                    con.Open();
                    using(var reader = cmd.ExecuteReader()){
                        while(reader.Read())
                        {
                            System.Console.WriteLine("Booyah");
                        }
                    }
                }
            }
            // TODO:  get a list of tables

            // TODO: generage markdown for each table

            // TODO:  save the file
        }

        
    }
}
