using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace SQLServerToDBML
{
    public class Program
    {
        static void Main(string[] args)
        {

            var connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTION_STRING");
            List<RawTable> rawTableData = new List<RawTable>();
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
                            var columnName = reader.GetValue(reader.GetOrdinal("column_name")).ToString();
                            var dataType = reader.GetValue(reader.GetOrdinal("data_type")).ToString();
                            var size = int.Parse(reader.GetValue(reader.GetOrdinal("size")).ToString());
                            var precision = float.Parse(reader.GetValue(reader.GetOrdinal("precision_scale")).ToString());
                            rawTableData.Add(new RawTable(tableName, columnName, dataType, size, precision));
                        }
                    }
                }
            }
        }

        private DBMLDatabase ProcessRaw(List<RawTable> rawData){
            var retval = new DBMLDatabase();

            return retval;
        }
        private string ConvertToDBML(DBMLDatabase database)
        {
            var output = new StringBuilder("//Table Definitions for " + database.DatabaseName);
            // TODO: generage markdown for each table
            foreach(var table in database.Tables){
                output.AppendLine("Table " + table.Name + "{");
                foreach(var column in table.Columns){
                    output.AppendLine("\t" + column.ColumnName + " " + column.Type);
                    if (column.IsPrimaryKey){
                        output.Append(" [pk]");
                    }
                }
                output.AppendLine("}");

            }

            return output.ToString();

        }

        private void SaveDBMLFile(string filePath){
            // TODO:  save the file
        }

    }

}
