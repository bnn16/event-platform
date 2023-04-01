﻿using event_platform_classLibrary.EventHandlers.Classes;
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
                command.CommandText = "INSERT INTO Events (Id, Name, Description,Date, Price, EventType, Capacity) VALUES (@Id, @Name, @Description, @Date, @Price, @EventType, @Capacity)";
                command.Parameters.AddWithValue("@Id", _event.Id);
                command.Parameters.AddWithValue("@Name", _event.Name);
                command.Parameters.AddWithValue("@Description", _event.Description);
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

        public async Task<bool> AddConcertAsync(ConcertEvent _event)
        {
            bool comm1;
            bool comm2;
            SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            {
                using (var command1 = connection.CreateCommand())
                {
                    command1.CommandText = "INSERT INTO Events (Id, Name, Description, Date, Price, EventType, Capacity) VALUES (@Id, @Name, @Description, @Date, @Price, @EventType, @Capacity)";
                    command1.Parameters.AddWithValue("@Id", _event.Id);
                    command1.Parameters.AddWithValue("@Name", _event.Name);
                    command1.Parameters.AddWithValue("@Description", _event.Description);
                    command1.Parameters.AddWithValue("@Date", _event.Date);
                    command1.Parameters.AddWithValue("@Price", _event.Price);
                    command1.Parameters.AddWithValue("@EventType", _event.EventType);
                    command1.Parameters.AddWithValue("@Capacity", _event.Capacity);

                    int rowsAffected1 = await command1.ExecuteNonQueryAsync();
                    if (rowsAffected1 > 0)
                    {
                        comm1 = true;
                    }
                    else
                    {
                        comm1 = false;
                    }

                }
                using (var command2 = connection.CreateCommand())
                {
                    command2.CommandText = "INSERT INTO Concerts (EventId, Artist, Venue) VALUES (@EventId, @Artist, @Venue)";
                    command2.Parameters.AddWithValue("@EventId", _event.Id);
                    command2.Parameters.AddWithValue("@Artist", _event.Artist);
                    command2.Parameters.AddWithValue("@Venue", _event.Venue);

                    int rowsAffected2 = await command2.ExecuteNonQueryAsync();
                    if (rowsAffected2 > 0)
                    {
                        comm2 = true;
                    }
                    else
                    {
                        comm2 = false;
                    }
                }
            }
            connection.Close();
            if (comm1 && comm2)
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