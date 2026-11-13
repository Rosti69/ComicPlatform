using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Rating
{
    public int Id { get; set; }

    [Range(1, 5)]
    public int Value { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int ComicId { get; set; }
    public Comic Comic { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = string.Empty;
    public AppUser User { get; set; } = null!;
}
