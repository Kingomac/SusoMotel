
namespace SusoAPI;

public class Location
{

  public static double distanceBetween(Location a, Location b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
  public static int distanceManhattanBetween(Location a, Location b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

  public int X { get; set; }
  public int Y { get; set; }

  public Location(int x, int y)
  {
    X = x;
    Y = y;
  }

  public double distanceTo(Location loc) => Location.distanceBetween(this, loc);
  public int distanceManhattanTo(Location loc) => Location.distanceManhattanBetween(this, loc);

}