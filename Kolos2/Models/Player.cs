﻿using System.ComponentModel.DataAnnotations;

namespace Kolos2.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; } = null!;
}