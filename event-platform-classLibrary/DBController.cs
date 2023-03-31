using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary
{
    public class DBController
    {
        private readonly string _connectionString = "Server=BNNXD\\SQLEXPRESS;Database=smilevents;Trusted_Connection=True;TrustServerCertificate=True;";

        public async Task<bool> AddEventAsync(Event _event)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Events (Id, Name, Date, Price, EventType, Capacity) VALUES (@Id, @Name, @Date, @Price, @EventType, @Capacity)";
                command.Parameters.AddWithValue("@Id", _event.Id);
                command.Parameters.AddWithValue("@Name", _event.Name);
                command.Parameters.AddWithValue("@Date", _event.Date);
                command.Parameters.AddWithValue("@Price", _event.Price);
                command.Parameters.AddWithValue("@EventType", _event.EventType);
                command.Parameters.AddWithValue("@Capacity", _event.Capacity);

                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
