namespace mustakuusi_cs_aspnetcore.Models;

public class Character
{
    public required string Id { get; set; }
    public string Name { get; set; } = "";
    public string ImageSrc { get; set; } = "";
    public string Description { get; set; } = "";
    public int Position { get; set; }
    
    public ICollection<GameCharacter> GameCharacters { get; set; } = new List<GameCharacter>();
}