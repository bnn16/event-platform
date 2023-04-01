using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary
{
    public class DBController
    {
        private readonly string _connectionString = "Server=BNNXD\\SQLEXPRESS;Database=smilevents;Trusted_Connection=True;TrustServerCertificate=True;";

        public async Task<bool> AddEventAsync(Event _event)
        {
            using (var con = new SqlConnection(_connectionString))
            using (var command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO Events (Id, Name, Description,Date, Price, EventType, Capacity) VALUES (@Id, @Name, @Description, @Date, @Price, @EventType, @Capacity)";
                command.Parameters.AddWithValue("@Id", _event.Id);
                command.Parameters.AddWithValue("@Name", _event.Name);
                command.Parameters.AddWithValue("@Description", _event.Description);
                command.Parameters.AddWithValue("@Date", _event.Date);
                command.Parameters.AddWithValue("@Price", _event.Price);
                command.Parameters.AddWithValue("@EventType", _event.EventType);
                command.Parameters.AddWithValue("@Capacity", _event.Capacity);

                await con.OpenAsync();
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
        //todo UpdateEventAsync and UpdateConcertAsync share common logic, combine the 2 methods into one
        //done, added the if statement to concat the string so I can check the events/type
        public async Task<bool> UpdateEventAsync(Event _event, int rId, string artist = null, string venue = null)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            await con.OpenAsync();

            using (var eventCommand = con.CreateCommand())
            {
                string updateCommand = "UPDATE Events SET Id = @newId, Name = @name, Description = @descr, Date = @date, Price = @price, EventType = @eventT, Capacity = @capacity WHERE Id = @oldId";
                if (artist != null && venue != null)
                {
                    updateCommand += "; UPDATE Concerts set Artist = @artist, Venue = @venue where EventId = @newId";
                }
                eventCommand.CommandText = updateCommand;

                eventCommand.Parameters.AddWithValue("@oldId", rId);
                eventCommand.Parameters.AddWithValue("@name", _event.Name);
                eventCommand.Parameters.AddWithValue("@descr", _event.Description);
                eventCommand.Parameters.AddWithValue("@date", _event.Date);
                eventCommand.Parameters.AddWithValue("@price", _event.Price);
                eventCommand.Parameters.AddWithValue("@eventT", _event.EventType);
                eventCommand.Parameters.AddWithValue("@capacity", _event.Capacity);
                eventCommand.Parameters.AddWithValue("@newId", _event.Id);
                if (artist != null && venue != null)
                {
                    eventCommand.Parameters.AddWithValue("@artist", artist);
                    eventCommand.Parameters.AddWithValue("@venue", venue);
                }

                return await eventCommand.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> AddConcertAsync(ConcertEvent _event)
        {
            bool comm1;
            bool comm2;
            SqlConnection con = new SqlConnection(_connectionString);
            await con.OpenAsync();
            {
                using (var command1 = con.CreateCommand())
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
                using (var command2 = con.CreateCommand())
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
            con.Close();
            if (comm1 && comm2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> DeleteEvent(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("delete from events where Id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }



        public DataTable GetAllEvents()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT E.*, C.* " +
                                   "FROM Events E " +
                                   "LEFT JOIN Concerts C ON E.Id = C.EventId " +
                                   "UNION " +
                                   "SELECT E.*, NULL AS C_Id, NULL AS Artist, NULL AS Venue " +
                                   "FROM Events E " +
                                   "WHERE NOT EXISTS (SELECT 1 FROM Concerts C WHERE C.EventId = E.Id)";

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
            }

            return dataTable;
        }


        //joins the tables via Id/EventId
        public DataSet GetEventById(int id)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT E.*, C.Artist, C.Venue FROM Events E LEFT JOIN Concerts C ON E.Id = C.EventId WHERE E.Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                // Use a SqlDataAdapter to fill a DataSet with the results of the query
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dataSet);
                }
            }
            return dataSet;
        }

        public DataTable GetEventByFilter(string filter) 
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand()) 
            { 
                cmd.Connection = con;
                cmd.CommandText = "SELECT E.*, C.Artist, C.Venue FROM Events E LEFT JOIN Concerts C ON E.Id = C.EventId WHERE E.Name LIKE @name + '%'";
                cmd.Parameters.AddWithValue("@name", filter);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
