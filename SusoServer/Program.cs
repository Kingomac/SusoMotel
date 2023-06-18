using SusoAPI;
using SusoServer.Controllers;
using MySqlConnector;

namespace SusoServer;

public class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Suso Server");
        User xd = new(1, 20000);
        xd.Money = 8923;
        MySqlConnectionStringBuilder settings = new();
        settings.Server = "172.19.0.2";
        settings.UserID = "root";
        settings.Password = "susoputa";
        settings.Database = "susomotel";
        ConnectionManager conn = new(settings.ToString());
        Console.WriteLine("Connection Manager started on thread " + Thread.CurrentThread.Name);
        UserController cont = new UserController(conn);

        cont.CreateTables();

        cont.Add(new(0, 0));

        cont.GetAll().GetAwaiter().GetResult().ForEach((i) =>
        {
            Console.WriteLine($"user: {i.Id} : {i.Money}");
        });

        Console.WriteLine("End");
    }

}