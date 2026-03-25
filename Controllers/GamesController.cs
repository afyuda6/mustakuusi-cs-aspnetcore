using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mustakuusi_cs_aspnetcore.Data;

[ApiController]
[Route("games")]
public class GamesController : ControllerBase
{
    private readonly AppDbContext _context;

    public GamesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetGames()
    {
        var games = await _context.Games
            .Include(g => g.Screenshots)
            .Include(g => g.GameCharacters)
            .ThenInclude(gc => gc.Character)
            .OrderByDescending(g => g.ReleaseDate)
            .ThenByDescending(g => g.Id)
            .ToListAsync();

        var result = games.Select(game => new
        {
            id = game.Id,
            title = game.Title,
            imageSrc = game.ImageSrc,
            date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                game.ReleaseDate, 
                "SE Asia Standard Time"
            ).ToString("yyyy-MM-ddTHH:mm:sszzz"),
            description = game.Description,
            categories = game.Categories.ToArray(),
            detail = game.Detail,
            privacyPolicyLink = game.PrivacyPolicyLink,
            downloadLink = game.DownloadLink,
            longDescription = game.LongDescription,
            screenshots = game.Screenshots.OrderBy(s => s.Id).Select(s => s.ImageSrc).ToArray(),
            characters = game.GameCharacters
                .OrderBy(gc => gc.Character.Position)
                .Select(gc => gc.Character.Id)
                .ToArray()
        });

        return Ok(result);
    }
}