using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;

[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
public class PlayerMatch
{
    [ForeignKey(nameof(Match))]
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;
    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    public int MVPs { get; set; }
    public double Rating { get; set; }
    
    
}