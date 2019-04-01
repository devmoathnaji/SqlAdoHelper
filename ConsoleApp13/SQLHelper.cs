using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLHelper<T>
    {
        private string _connection;
        private string _query;
        public SQLHelper(string connectionString, string query)
        {
            _connection = connectionString;
            _query = query;
        }

        public int ExecuteNonQuery()
        {
            using (var sql = new SqlConnection(_connection))
            {
                using (var cmd = new SqlCommand(_query))
                {
                    cmd.Connection = sql;
                    sql.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public async Task<int> ExecuteNonQueryAsync()
        {
            using (var sql = new SqlConnection(_connection))
            {
                using (var cmd = new SqlCommand(_query))
                {
                    cmd.Connection = sql;
                    await sql.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public T ExecuteScaler()
        {
            using (var sql = new SqlConnection(_connection))
            {
                using (var cmd = new SqlCommand(_query))
                {
                    cmd.Connection = sql;
                    sql.Open();
                    var res = (T)cmd.ExecuteScalar();
                    return res;
                }
            }
        }
        public async Task<T> ExecuteScalerAsync()
        {
            using (var sql = new SqlConnection(_connection))
            {

                using (var cmd = new SqlCommand(_query))
                {
                    cmd.Connection = sql;
                    sql.Open();
                    var res = (T)await cmd.ExecuteScalarAsync();
                    return res;
                }
            }
        }
        public List<T> ExecuteReader()
        {
            var results = new List<T>();
            using (var sql = new SqlConnection(_connection))
            {
                using (var cmd = new SqlCommand(_query))
                {
                    cmd.Connection = sql;
                    sql.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = Activator.CreateInstance<T>();
                        foreach (var property in typeof(T).GetProperties())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                            {
                                Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
                            }
                        }
                        results.Add(item);
                    }
                    return results;
                }
            }
        }

        public async Task<List<T>> ExecuteReaderAsync()
        {
            var results = new List<T>();
            using (var sql = new SqlConnection(_connection))
            {
                using (var cmd = new SqlCommand(_query))
                {
                    cmd.Connection = sql;
                     await sql.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var item = Activator.CreateInstance<T>();
                        foreach (var property in typeof(T).GetProperties())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                            {
                                Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
                            }
                        }
                        results.Add(item);
                    }
                    return results;
                }
            }
        }
    }
}
