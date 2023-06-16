namespace SusoAPI;

public record Room(string Id, int Width, int Height, Location DoorLocation)
{
    public string Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Location DoorLocation { get; set; }
}