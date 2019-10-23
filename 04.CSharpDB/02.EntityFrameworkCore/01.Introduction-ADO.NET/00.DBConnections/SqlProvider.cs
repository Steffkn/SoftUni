using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace _00.DBConnections
{
    public class SqlProvider
    {
        private string connectionString;

        public SqlProvider()
            : this(Consts.connectionString)
        {
        }

        public SqlProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int ExecuteNonQuery(string query)
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }

        public void ExecuteReader(string query, Action<IDataRecord> readSingleRow, params Tuple<string, object>[] parameters)
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Item1, param.Item2);
            }

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                readSingleRow(reader);
            }
        }

        public object ExecuteScalar(string query, params Tuple<string, object>[] parameters)
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Item1, param.Item2);
            }

            return command.ExecuteScalar();
        }
    }
}
