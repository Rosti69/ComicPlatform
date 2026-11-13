using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Notification
{
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string Message { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Type { get; set; } = "General";

    [MaxLength(500)]
    public string? RelatedUrl { get; set; }

    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public string UserId { get; set; } = string.Empty;
    public AppUser User { get; set; } = null!;
}
