namespace SusoAPI;

public record MovementOrder(string UserId, Location Destiny)
{
    public required string UserId { get; init; }
    public required Location Destiny { get; init; }
}
