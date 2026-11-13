using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public int ComicId { get; set; }
    public Comic Comic { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = string.Empty;
    public AppUser User { get; set; } = null!;
}
