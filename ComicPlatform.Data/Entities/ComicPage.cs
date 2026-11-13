using System.ComponentModel.DataAnnotations;

namespace ComicPlatform.Data.Entities;

public class ComicPage
{
    public int Id { get; set; }
    public int PageNumber { get; set; }

    [Required]
    [MaxLength(1000)]
    public string ImageUrl { get; set; } = string.Empty;

    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; } = null!;
}
