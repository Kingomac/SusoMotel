
namespace SusoAPI;

public record User(string Id, long Money)
{
    public string Id { get; init; }

    public long Money { get; set; }

}