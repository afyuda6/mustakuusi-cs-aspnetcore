namespace mustakuusi_cs_aspnetcore.Models;

public class GameCharacter
{
    public required string GameId { get; set; }
    public Game Game { get; set; } = null!;

    public required string CharacterId { get; set; }
    public Character Character { get; set; } = null!;
}