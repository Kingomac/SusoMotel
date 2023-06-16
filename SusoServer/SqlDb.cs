using MySqlConnector;

namespace SusoServer;

public class SqlDb
{

    private MySqlConnection connection;

    public SqlDb(string server = "127.0.0.1", string uid = "root", string pwd = "1234", string database = "suso")
    {
        MySqlConnectionStringBuilder settings = new();
        settings.Server = server;
        settings.UserID = uid;
        settings.Password = pwd;
        settings.Database = database;
        connection = new MySqlConnection(settings.ToString());
        connection.OpenAsync();
    }

    public SqlDb(string connectionUrl)
    {
        connection = new MySqlConnection(connectionUrl);
        connection.OpenAsync();
    }

    public async void Close()
    {
        await connection.CloseAsync();
    }
}