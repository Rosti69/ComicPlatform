using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class Tag
{
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;

    public ICollection<ComicTag> ComicTags { get; set; } = new List<ComicTag>();
}
