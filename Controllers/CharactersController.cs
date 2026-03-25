using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mustakuusi_cs_aspnetcore.Data;

[ApiController]
[Route("characters")]
public class CharactersController : ControllerBase
{
    private readonly AppDbContext _context;

    public CharactersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCharacters()
    {
        var characters = await _context.Characters
            .OrderBy(c => c.Position)
            .ToListAsync();

        var result = characters.Select(c => new
        {
            id = c.Id,
            name = c.Name,
            imageSrc = c.ImageSrc,
            description = c.Description
        });

        return Ok(result);
    }
}