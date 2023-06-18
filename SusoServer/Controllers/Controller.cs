public abstract class Controller
{
    protected ConnectionManager ConnectionManager { get; }

    public Controller(ConnectionManager conn)
    {
        ConnectionManager = conn;
    }
}