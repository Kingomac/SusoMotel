using MySqlConnector;

public class ConnectionManager
{
    public string ConnectionString { get; }

    private MySqlConnection? openedConnection = null;
    public ConnectionManager(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<MySqlConnection> Connect()
    {
        MySqlConnection conn = new(ConnectionString);
        await conn.OpenAsync();
        openedConnection = conn;
        return conn;
    }

    public async void Disconnect(MySqlConnection conn)
    {
        await conn.DisposeAsync();
        await conn.CloseAsync();
    }

    public async void Disconnect()
    {
        if (openedConnection == null) throw new Exception("openendConnection in ConnectionManager was null and tried to disconnect");
        await openedConnection.DisposeAsync();
        await openedConnection.CloseAsync();
    }
}