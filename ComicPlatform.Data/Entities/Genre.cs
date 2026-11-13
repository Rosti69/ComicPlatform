using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Genre
{
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;

    public ICollection<ComicGenre> ComicGenres { get; set; } = new List<ComicGenre>();
}
