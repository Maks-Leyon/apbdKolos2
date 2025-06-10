using Kolos2.DTOs;

namespace Kolos2.Services;

public interface IPlayersService
{
    Task<GetPlayerMatchesDTO> GetPlayerMatchesById(int playerId);
    Task PostPlayer(PostPlayerDTO postBody);
}