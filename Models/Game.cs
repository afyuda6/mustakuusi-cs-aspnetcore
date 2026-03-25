namespace mustakuusi_cs_aspnetcore.Models;

public class Game
{
    public required string Id { get; set; }
    public string Title { get; set; } = "";
    public string ImageSrc { get; set; } = "";
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; } = "";
    public string Detail { get; set; } = "";
    public string PrivacyPolicyLink { get; set; } = "";
    public string DownloadLink { get; set; } = "";
    public string LongDescription { get; set; } = "";

    public string[] Categories { get; set; } = Array.Empty<string>();
    public ICollection<Screenshot> Screenshots { get; set; } = new List<Screenshot>();
    public ICollection<GameCharacter> GameCharacters { get; set; } = new List<GameCharacter>();
}