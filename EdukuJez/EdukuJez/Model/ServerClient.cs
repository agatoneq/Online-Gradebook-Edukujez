using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EdukuJez
{
    static public class ServerClient
    {

        static public async Task<List<Dictionary<string, object>>> SendRequestToSqlServer(string quary)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            string connectionString = @"Data Source=DESKTOP-602DCUI;Initial Catalog=Edukujez;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, object> rowData = new Dictionary<string, object>();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    object columnValue = reader[i];
                                    rowData.Add(columnName, columnValue);
                                }

                                data.Add(rowData);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    data = null;
                }
            }
            return data;
        }
    }
}