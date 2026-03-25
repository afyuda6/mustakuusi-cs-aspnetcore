namespace mustakuusi_cs_aspnetcore.Models;

public class Screenshot
{
    public required string Id { get; set; }
    public string ImageSrc { get; set; } = "";
    public required string GameId { get; set; }
    public Game Game { get; set; } = null!;
}