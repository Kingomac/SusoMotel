using MySqlConnector;
using SusoAPI;

namespace SusoServer.Controllers;

public class UserController : Controller
{
    public UserController(ConnectionManager conn) : base(conn)
    {
    }

    public async Task<List<User>> GetAll()
    {
        List<User> toret = new();
        MySqlCommand cmd = new(
            "SELECT * FROM user", await ConnectionManager.Connect());
        MySqlDataReader reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            toret.Add(new(
                reader.GetUInt32(0),
                reader.GetUInt32(1)
            ));
        }
        ConnectionManager.Disconnect();
        await cmd.DisposeAsync();
        return toret;
    }

    public async Task<User> GetById(uint id)
    {
        MySqlCommand cmd = new(
            "SELECT * FROM user WHERE id=@id", await ConnectionManager.Connect()
        );
        cmd.Parameters.AddWithValue("id", id);
        MySqlDataReader reader = await cmd.ExecuteReaderAsync();
        User toret = new(
            id, reader.GetUInt32(1)
        );
        ConnectionManager.Disconnect();
        await cmd.DisposeAsync();
        return toret;
    }

    public async void Add(User user)
    {
        using (MySqlCommand cmd = new())
        {
            cmd.Connection = await ConnectionManager.Connect();
            cmd.CommandText = $"INSERT INTO user (id, money) VALUES (DEFAULT, DEFAULT)";
            cmd.Parameters.AddWithValue("id", user.Id);
            cmd.Parameters.AddWithValue("money", user.Money);
            await cmd.ExecuteNonQueryAsync();
            ConnectionManager.Disconnect();
            await cmd.DisposeAsync();
        }
    }

    public async void CreateTables()
    {
        using (MySqlCommand cmd = new())
        {
            cmd.Connection = await ConnectionManager.Connect();
            cmd.CommandText = @"CREATE TABLE user (
                id INT UNSIGNED AUTO_INCREMENT NOT NULL PRIMARY KEY,
                money INT UNSIGNED NOT NULL DEFAULT 0
            );";
            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync("Table user cannot be created. It's probably that it already exists: " + e.Message);
                await Console.Error.WriteLineAsync(e.StackTrace);
            }
            finally
            {
                ConnectionManager.Disconnect();
                await cmd.DisposeAsync();
            }
        }
    }
}