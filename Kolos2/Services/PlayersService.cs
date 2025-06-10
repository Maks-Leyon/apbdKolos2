using Kolos2.Data;
using Kolos2.DTOs;
using Kolos2.Exceptions;
using Kolos2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Kolos2.Services;

public class PlayersService : IPlayersService
{
    private readonly DatabaseContext _context;

    public PlayersService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetPlayerMatchesDTO> GetPlayerMatchesById(int playerId)
    {
        var playerMatches = await _context.Players
            .Select(e => new GetPlayerMatchesDTO
            {
                PlayerId = e.PlayerId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                BirthDate = e.BirthDate,
                Matches = e.PlayerMatches.Select(e => new MatchDTO
                {
                    Tournament = e.Match.Tournament.Name,
                    Map = e.Match.Map.Name,
                    Date = e.Match.MatchDate,
                    MVPs = e.MVPs,
                    Rating = e.Rating,
                    Team1Score = e.Match.Team1Score,
                    Team2Score = e.Match.Team2Score
                }).ToList(),
            }).FirstOrDefaultAsync();

        if (playerMatches is null)
        {
            throw new NotFoundException("Nie znaleziono żadnych meczów dla podanego gracza");
        }
        
        return playerMatches;
    }

    public async Task PostPlayer(PostPlayerDTO postBody)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (postBody.FirstName.IsNullOrEmpty() || postBody.LastName.IsNullOrEmpty())
            {
                throw new ConflictException("Nieprawidłowe dane");
            }

            var player = new Player
            {
                FirstName = postBody.FirstName,
                LastName = postBody.LastName,
                BirthDate = postBody.BirthDate,
            };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            var newMatches = new List<PlayerMatch>();

            foreach (var match in postBody.Matches)
            {
                var m = await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == match.MatchId);
                if (m is null)
                {
                    throw new NotFoundException("Mecz nie znaleziony");
                }

                if (m.BestRating >= match.Rating)
                {
                    m.BestRating = match.Rating;
                }

                newMatches.Add(new PlayerMatch()
                {
                    MatchId = match.MatchId,
                    MVPs = match.MVPs,
                    Rating = match.Rating,
                });
            }

            await _context.PlayerMatches.AddRangeAsync(newMatches);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

}