using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SQLServerToDBML
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTION_STRING");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    var sql = @"SELECT 
                                    T.name AS table_name ,
                                    C.name AS column_name ,
                                    P.name AS data_type ,
                                    P.max_length AS size ,
                                    CAST(P.precision AS VARCHAR) + '/' + CAST(P.scale AS VARCHAR) AS precision_scale
                                FROM   sys.objects AS T
                                    JOIN sys.columns AS C ON T.object_id = C.object_id
                                    JOIN sys.types AS P ON C.system_type_id = P.system_type_id
                                WHERE  T.type_desc = 'USER_TABLE';";
                    cmd.CommandText = sql;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tableName = reader.GetValue(reader.GetOrdinal("table_name")).ToString();
                            System.Console.WriteLine(tableName);
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
