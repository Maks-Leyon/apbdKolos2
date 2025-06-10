using System.ComponentModel.DataAnnotations;

namespace Kolos2.Models;

public class Map
{
    [Key]
    public int MapId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public ICollection<Match> Matches { get; set; } = null!;
}