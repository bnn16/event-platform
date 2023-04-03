using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.Data.SqlClient;
using System.Data;


namespace event_platform_classLibrary
{
    public class DBController
    {
        private readonly string _connectionString;
        public DBController()
        {
            //todo add connection string with .env
            //Env.Load();
            //_connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTIONSTRING");
            _connectionString = "Server=MSI\\SQLEXPRESS;Database=smilevents;Trusted_Connection=True;TrustServerCertificate=True;";

        }


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

            if (_connectionString == null)
            {
                throw new ArgumentNullException(nameof(_connectionString));
            }

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
        public (List<Event>, List<ConcertEvent>) GetListOfEvents()
        {
            List<Event> eventList = new List<Event>();
            List<ConcertEvent> concertList = new List<ConcertEvent>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT E.Id, E.Name, E.Description, E.Date, E.Price, E.EventType, E.Capacity, C.Artist, C.Venue
                    FROM Events E
                    LEFT JOIN Concerts C ON E.Id = C.EventId
                    ORDER BY E.Date, C.EventId
                ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string desc = reader.GetString(2);
                            DateTime date = reader.GetDateTime(3);
                            int price = Convert.ToInt32(reader.GetDecimal(4));
                            string eventType = reader.GetString(5);
                            int capacity = reader.GetInt32(6);

                            if (!reader.IsDBNull(7))
                            {
                                // This is a concert
                                string artist = reader.GetString(7);
                                string venue = reader.GetString(8);

                                ConcertEvent concertObj = new ConcertEvent(id, name, desc, date, price, eventType, capacity, artist, venue);

                                concertList.Add(concertObj);
                            }
                            else
                            {
                                // This is an event
                                Event eventObj = new Event(id, name, desc, date, price, eventType, capacity);

                                eventList.Add(eventObj);
                            }
                        }
                    }
                }
            }

            return (eventList, concertList);
        }

        public (List<Event>, List<ConcertEvent>) GetMyEvents(int userId)
        {
            List<Event> eventList = new List<Event>();
            List<ConcertEvent> concertList = new List<ConcertEvent>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
            SELECT E.Id, E.Name, E.Description, E.Date, E.Price, E.EventType, E.Capacity, C.Artist, C.Venue
            FROM Events E
            LEFT JOIN Concerts C ON E.Id = C.EventId
            INNER JOIN Bookings B ON E.Id = B.EventId AND B.UserId = @userId
            ORDER BY E.Date, C.EventId
        ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string desc = reader.GetString(2);
                            DateTime date = reader.GetDateTime(3);
                            int price = reader.GetInt32(4);
                            string eventType = reader.GetString(5);
                            int capacity = reader.GetInt32(6);

                            if (!reader.IsDBNull(7))
                            {
                                // This is a concert
                                string artist = reader.GetString(7);
                                string venue = reader.GetString(8);

                                ConcertEvent concertObj = new ConcertEvent(id, name, desc, date, price, eventType, capacity, artist, venue);

                                concertList.Add(concertObj);
                            }
                            else
                            {
                                // This is an event
                                Event eventObj = new Event(id, name, desc, date, price, eventType, capacity);

                                eventList.Add(eventObj);
                            }
                        }
                    }
                }
            }

            return (eventList, concertList);
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

        public Event GetEventByIdObj(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Events WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", eventId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Event eventObj = new Event(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            (int)reader.GetDecimal(4),
                            reader.GetString(5),
                            reader.GetInt32(6)
                        );
                        return eventObj;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
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


        //User part starts now -------


        public User GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            User user = null;

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Username, Email, PasswordHash, Role, short_desc FROM Users WHERE Username = @UsernameOrEmail OR Email = @UsernameOrEmail";
                command.Parameters.AddWithValue("@UsernameOrEmail", usernameOrEmail);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(2),
                            PasswordHash = reader.GetString(3),
                            Role = reader.GetString(4),
                            Description = reader.IsDBNull(5) ? null : reader.GetString(4)
                        };
                    }
                }
            }

            return user;
        }
        //using method overloading to use either string or LoginBindModel.
        public User GetUserByUsernameOrEmail(LoginBindModel input)
        {
            return GetUserByUsernameOrEmail(input.UsernameOrEmail);
        }

        //using transaction because if errors are encountered, all data modifications made after the BEGIN TRANSACTION can be rolled back to return the data to this known state of consistency
        public async Task<bool> RegisterUserAsync(RegisterBindModel Input)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "INSERT INTO Users (Username, Email, PasswordHash, Role, short_desc) VALUES (@Username, @Email, @PasswordHash, @role, @short_desc)";
                            command.Parameters.AddWithValue("@Username", Input.Username);
                            command.Parameters.AddWithValue("@Email", Input.Email);
                            command.Parameters.AddWithValue("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(Input.Password));
                            command.Parameters.AddWithValue("@role", "User");
                            command.Parameters.AddWithValue("@short_desc", "");

                            await command.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                    return true;
                }

            }
        }
        public void InsertAuthToken(int userId, string token)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO AuthTokens (UserId, Token) VALUES (@UserId, @Token)";
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Token", token);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAuthToken(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM AuthTokens WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }


        public bool IsAuthTokenValid(int userId, string authToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM AuthTokens WHERE UserId = @UserId AND Token = @Token";
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Token", authToken);

                connection.Open();

                int count = (int)command.ExecuteScalar();

                return count == 1;
            }
        }


        public User GetUserById(int userId)
        {
            User user = null;

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Username, Email, short_desc FROM Users WHERE Id = @UserId";
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }

            return user;
        }
        public bool AddBooking(int eventId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Bookings (UserId, EventId) VALUES (@UserId, @EventId)", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@EventId", eventId);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public void UpdateEvent(Event updatedEvent)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Events SET Name = @Name, Description = @Description, " +
                               "Date = @Date, Price = @Price, EventType = @EventType, Capacity = @Capacity " +
                               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", updatedEvent.Id);
                    command.Parameters.AddWithValue("@Name", updatedEvent.Name);
                    command.Parameters.AddWithValue("@Description", updatedEvent.Description);
                    command.Parameters.AddWithValue("@Date", updatedEvent.Date);
                    command.Parameters.AddWithValue("@Price", updatedEvent.Price);
                    command.Parameters.AddWithValue("@EventType", updatedEvent.EventType);
                    command.Parameters.AddWithValue("@Capacity", updatedEvent.Capacity);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        
        public bool HasBookedEvent(int eventId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Bookings WHERE UserId = @UserId AND EventId = @EventId", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@EventId", eventId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

    }
}
