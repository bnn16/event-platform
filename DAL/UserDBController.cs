using event_platform_classLibrary.EventHandlers.Classes;
using event_platform_classLibrary;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class UserDBController : IUserDBController
    {
        private readonly string _connectionString;

        public UserDBController()
        {
            _connectionString = "Server=BOGDANNIKOL1867\\SQLEXPRESS;Database=smile;Trusted_Connection=True;TrustServerCertificate=True;";
        }


        //using method overloading to use either string or LoginBindModel.
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

        public void InsertSickLeave(int userId, DateTime start, DateTime end, string description)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Sick (PersonId, LeaveStart, LeaveEnd, PersonMsg) VALUES (@personId, @leaveStart, @leaveEnd, @personMsg)";
                command.Parameters.AddWithValue("@personId", userId);
                command.Parameters.AddWithValue("@leaveStart", start);
                command.Parameters.AddWithValue("@leaveEnd", end);
                command.Parameters.AddWithValue("@personMsg", description);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

       

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Username, Email, short_desc, Role, isAvailable " +
                               "FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Email = reader.GetString(2),
                                Description = reader.GetString(3),
                                Role = reader.GetString(4),
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Users SET Username = @Username, Email = @Email, short_desc = @Description WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Description", user.Description);
                    command.Parameters.AddWithValue("@Id", user.Id);

                    await connection.OpenAsync();
                    int affectedRows = await command.ExecuteNonQueryAsync();

                    return affectedRows > 0;
                }
            }
        }
    }
}