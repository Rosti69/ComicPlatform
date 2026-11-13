namespace ComicPlatform.Data.Entities;

public class Favorite
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int ComicId { get; set; }
    public Comic Comic { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;
    public AppUser User { get; set; } = null!;
}
