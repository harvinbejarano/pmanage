using Repositories.Core;
using Repositories.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class ClientRepository : IClientRepository
    {
        private string connStr;

        public ClientRepository()
        {
            connStr= ConfigurationManager.ConnectionStrings["testDBConnectionString"].ConnectionString;
        }

        public async Task<Client> AddClient(Client entity)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "add_client"

                };

                command.Parameters.AddRange( GetParametersFromClient(entity).ToArray() );

                await command.ExecuteNonQueryAsync();
            }

            return entity;
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> list = new List<Client>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "get_clients"

                };

                SqlDataReader reader = await command.ExecuteReaderAsync();
                list = GetClientListFromReader(reader);

            }
            return list;
        }


        private List<SqlParameter> GetParametersFromClient(Client client)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("Name", client.Name));
            list.Add(new SqlParameter("Address", client.Address));

            return list;
        }

        private List<Client> GetClientListFromReader(SqlDataReader reader)
        {
            List<Client> list = new List<Client>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Client client = new Client()
                    {
                        Id = reader.GetInt32(0),
                        Name= reader.GetString(1),
                        Address = reader.GetString(2)

                    };
                    list.Add(client);
                }
            }

            return list;
        }
    }
}
