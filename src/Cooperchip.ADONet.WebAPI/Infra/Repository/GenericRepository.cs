using Cooperchip.ADONet.WebAPI.Configurations;
using Cooperchip.ADONet.WebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ADONet.WebAPI.Infra.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly string? _connectionString;


        public GenericRepository(IOptions<ConnectionStringOptions> options)
        {
            _connectionString = options.Value.DefaultConnection;
        }
    

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {typeof(T).Name}";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var obj = Activator.CreateInstance<T>();
                            foreach (var prop in typeof(T).GetProperties())
                            {
                                prop.SetValue(obj, reader[prop.Name]);
                            }
                            result.Add(obj);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            T? result = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id=@Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            result = Activator.CreateInstance<T>();
                            foreach (var prop in typeof(T).GetProperties())
                            {
                                prop.SetValue(result, reader[prop.Name]);
                            }
                        }
                    }
                }
            }
            return result;            
        }

        //public async Task AddAsync(T entity)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();
        //        using (var command = connection.CreateCommand())
        //        {
        //            var columns = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
        //            var values = string.Join(",", typeof(T).GetProperties().Select(p => "@" + p.Name));
        //            command.CommandText = $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})";
        //            foreach (var prop in typeof(T).GetProperties())
        //            {
        //                command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity));
        //            }
        //            await command.ExecuteNonQueryAsync();
        //        }
        //    }
        //}

        public async Task AddAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    // Obtém todas as propriedades da classe T exceto a propriedade Id
                    var properties = typeof(T).GetProperties().Where(p => p.Name != "Id");
                    var columns = string.Join(",", properties.Select(p => p.Name));
                    var values = string.Join(",", properties.Select(p => "@" + p.Name));
                    command.CommandText = $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values}); SELECT SCOPE_IDENTITY();";
                    foreach (var prop in properties)
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity));
                    }

                    // Obtém o valor gerado automaticamente para a coluna de identidade
                    var id = await command.ExecuteScalarAsync();

                    // Define o valor da propriedade Id do objeto entity com o valor gerado automaticamente pelo banco de dados
                    typeof(T).GetProperty("Id")?.SetValue(entity, Convert.ToInt32(id));
                }
            }
        }


        //public async Task UpdateAsync(T entity)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();
        //        using (var command = connection.CreateCommand())
        //        {
        //            var setValues = string.Join(",", typeof(T).GetProperties().Select(p => $"{p.Name}=@{p.Name}"));
        //            command.CommandText = $"UPDATE {typeof(T).Name} SET {setValues} WHERE Id=@Id";
        //            foreach (var prop in typeof(T).GetProperties())
        //            {
        //                command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity));
        //            }
        //            await command.ExecuteNonQueryAsync();
        //        }
        //    }
        //}


        public async Task UpdateAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    var setValues = string.Join(",", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"{p.Name}=@{p.Name}"));
                    command.CommandText = $"UPDATE {typeof(T).Name} SET {setValues} WHERE Id=@Id";
                    foreach (var prop in typeof(T).GetProperties())
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity));
                    }
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE Id=@Id";
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}
