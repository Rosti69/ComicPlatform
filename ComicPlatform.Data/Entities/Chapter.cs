using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Chapter
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public int ChapterNumber { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAt { get; set; }

    public int ComicId { get; set; }
    public Comic Comic { get; set; } = null!;

    public ICollection<ComicPage> Pages { get; set; } = new List<ComicPage>();
}
