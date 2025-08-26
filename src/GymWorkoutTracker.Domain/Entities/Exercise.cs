using System.ComponentModel.DataAnnotations;

namespace GymWorkoutTracker.Domain.Entities;

public class Exercise
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    public string? Description { get; set; }
}