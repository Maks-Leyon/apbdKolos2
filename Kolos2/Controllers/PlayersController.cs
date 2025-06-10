using Kolos2.DTOs;
using Kolos2.Exceptions;
using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayersService _playersService;

    public PlayersController(IPlayersService playersService)
    {
        _playersService = playersService;
    }
    
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        try
        {
            var matches = await _playersService.GetPlayerMatchesById(id);
            return Ok(matches);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> PostPlayerMatches(PostPlayerDTO postBody)
    {
        try
        {
            await _playersService.PostPlayer(postBody);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}