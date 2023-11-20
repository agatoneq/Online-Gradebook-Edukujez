using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EdukuJez
{
    public class ServerClient
    {
        static ServerClient _instance;
        readonly SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-602DCUI;Initial Catalog=Edukujez;Integrated Security=True");
        public static new ServerClient StartConnection()
        {
            if (_instance == null)
            {
                _instance = new ServerClient();
            }
            return new ServerClient();
        }


        private ServerClient()
        { 
        
        
        }
        public async Task<List<Dictionary<string, object>>> SendRequestToSqlServer(string query)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();


            try
            {
                await connection.OpenAsync().ConfigureAwait(false);

                using (SqlCommand command = new SqlCommand(query, connection))
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

            return data;
        }
    }
}