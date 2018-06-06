using MusicApplication.Services.contracts;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MusicApplication.Services
{
    public class SingleService : ISingleService
    {
        private string connectionString;

        public SingleService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MusicApplication.Data.Single GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetSingleById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SingleId", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var single = new MusicApplication.Data.Single(reader);
                            return single;
                        }
                    }

                    return null;
                }
            }
        }


        public MusicApplication.Data.Single UpdateSingle(int id, MusicApplication.Data.Single single)
        {
            throw new NotImplementedException();
        }


        public MusicApplication.Data.Single CreateSingle(MusicApplication.Data.Single single)
        {
            throw new NotImplementedException();
        }


        public bool DeleteSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
