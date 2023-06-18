
namespace SusoAPI;

public record User(uint Id, uint Money)
{
    public uint Id { get; init; } = Id;

    public uint Money { get; set; } = Money;

}