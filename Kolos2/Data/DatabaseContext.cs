using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Match> Matches { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Player> Players { get; set; }

    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasData(new List<Player>()
        {
            new Player() { PlayerId = 1, FirstName = "John", LastName = "Doe", BirthDate = DateTime.Parse("2000-05-20")},
            new Player() { PlayerId = 2, FirstName = "Jane", LastName = "Doe", BirthDate = DateTime.Parse("2001-05-20") },
            new Player() { PlayerId = 3, FirstName = "Julie", LastName = "Doe", BirthDate = DateTime.Parse("2002-05-20") },
        });
        
        modelBuilder.Entity<Map>().HasData(new List<Map>()
        {
            new Map() { MapId = 1, Name = "Inferno", Type = "A"},
            new Map() { MapId = 2, Name = "Mirage", Type = "B"},
            new Map() { MapId = 3, Name = "Dust", Type = "C"},
        });
        
        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>()
        {
            new Tournament() { TournamentId = 1, Name = "CS2 Summer Cup", StartDate = DateTime.Parse("2025-07-01"), EndDate = DateTime.Parse("2025-07-03")},
            new Tournament() { TournamentId = 2, Name = "CS2 Fall Cup", StartDate = DateTime.Parse("2025-01-01"), EndDate = DateTime.Parse("2025-01-03")},
        });
        
        modelBuilder.Entity<Match>().HasData(new List<Match>()
        {
            new Match() { MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Parse("2025-07-02"), Team1Score = 16, Team2Score = 12, BestRating = 1.25},
            new Match() { MatchId = 2, TournamentId = 1, MapId = 2, MatchDate = DateTime.Parse("2025-07-03"), Team1Score = 10, Team2Score = 16, BestRating = 1.1},
        });
        
        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>()
        {
            new PlayerMatch() { MatchId = 1, PlayerId = 1, MVPs = 3, Rating = 1.25},
            new PlayerMatch() { MatchId = 2, PlayerId = 1, MVPs = 2, Rating = 1.1},
        });
    }
    
}