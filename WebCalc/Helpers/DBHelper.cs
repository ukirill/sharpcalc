using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebCalc.Helpers
{



    public class DBHelper
    {

        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\sharpcalc\WebCalc\App_Data\CalcStorage.mdf;Integrated Security=True";

        public static IEnumerable<object> GetAllFromTable(string table, string sortBy = "")
        {

            var sqlquery = sortBy != "" ? $"SELECT * FROM {table} ORDER BY {sortBy}" : $"SELECT * FROM {table}";

            List<object> result = new List<object>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command =  new SqlCommand(sqlquery, conn);

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {

                        var item = new Dictionary<int, object>();

                        for (int i = 0; i<reader.FieldCount; i++)
                        {
                            item.Add(i, reader[i]);
                        }
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public static void InsertTable(string table, IList<object> item)
        {
            var values = item.Select(i => i == null ? "NULL" 
                                    :i is string || i is DateTime
                                    ? $"'{i}'" 
                                    : i is double 
                                    ? ((double)i).ToString(CultureInfo.InvariantCulture)
                                    : $"{i}");

            var sqlquery = $"INSERT INTO {table} VALUES({string.Join(",", values)}) ";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);

                conn.Open();

                command.ExecuteNonQuery();
            }
        }

        public static void UpdateTable(string table, Dictionary<string, object> item, object id)
        {
            var values = item.Select(i => i.Value == null ? $"{i.Key}=NULL"
                            :i.Value is string || i.Value is DateTime 
                            ? $"{i.Key}='{i.Value}'"
                            : i.Value is double 
                            ? $"{i.Key}={((double)i.Value).ToString(CultureInfo.InvariantCulture)}" 
                            : $"{i.Key}={i.Value}");


            var sqlquery = $"UPDATE {table} SET {string.Join(",", values)} WHERE Id={id}";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);

                conn.Open();

                command.ExecuteNonQuery();
            }
        }

    }

}