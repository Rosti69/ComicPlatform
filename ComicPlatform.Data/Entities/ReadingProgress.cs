namespace ComicPlatform.Data.Entities;

public class ReadingProgress
{
    public int Id { get; set; }

    public int ComicId { get; set; }
    public Comic Comic { get; set; } = null!;

    public int? ChapterId { get; set; }
    public Chapter? Chapter { get; set; }

    public int PageNumber { get; set; }
    public DateTime LastReadAt { get; set; } = DateTime.UtcNow;

    public string UserId { get; set; } = string.Empty;
    public AppUser User { get; set; } = null!;
}
