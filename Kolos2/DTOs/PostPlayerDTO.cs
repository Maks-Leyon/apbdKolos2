namespace Kolos2.DTOs;

public class PostPlayerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<PostMatchDTO> Matches { get; set; }
}

public class PostMatchDTO
{
    public int MatchId { get; set; }
    public int MVPs { get; set; }
    public double Rating { get; set; }
}