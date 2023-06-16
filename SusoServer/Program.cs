using SusoAPI;

namespace SusoServer;

public class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Suso Server");
        User xd = new("pene", 2);
        xd.Money = 8923;

        SqlDb db = new("172.19.0.2", "root", "susoputa", "susomotel");
        Console.WriteLine("Connected i guess");
        db.Close();
        Console.WriteLine("End");
    }

}