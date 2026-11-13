using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Comic
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(3000)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? CoverImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? PublishedAt { get; set; }

    public ComicStatus Status { get; set; } = ComicStatus.Draft;

    [Required]
    public string AuthorId { get; set; } = string.Empty;
    public AppUser Author { get; set; } = null!;

    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    public ICollection<ComicGenre> ComicGenres { get; set; } = new List<ComicGenre>();
    public ICollection<ComicTag> ComicTags { get; set; } = new List<ComicTag>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<ReadingProgress> ReadingProgresses { get; set; } = new List<ReadingProgress>();
}
