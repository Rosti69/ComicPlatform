using ComicPlatform.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicPlatform.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Comic> Comics => Set<Comic>();
    public DbSet<Chapter> Chapters => Set<Chapter>();
    public DbSet<ComicPage> ComicPages => Set<ComicPage>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<ComicGenre> ComicGenres => Set<ComicGenre>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<ComicTag> ComicTags => Set<ComicTag>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<ReadingProgress> ReadingProgresses => Set<ReadingProgress>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comic>(entity =>
        {
            entity.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.HasIndex(x => x.Title);

            entity.HasOne(x => x.Author)
                .WithMany(x => x.CreatedComics)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasIndex(x => new { x.ComicId, x.ChapterNumber }).IsUnique();

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.Chapters)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ComicPage>(entity =>
        {
            entity.HasIndex(x => new { x.ChapterId, x.PageNumber }).IsUnique();

            entity.HasOne(x => x.Chapter)
                .WithMany(x => x.Pages)
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.HasIndex(x => x.Slug).IsUnique();

            entity.HasData(
                new Genre { Id = 1, Name = "Action", Slug = "action" },
                new Genre { Id = 2, Name = "Adventure", Slug = "adventure" },
                new Genre { Id = 3, Name = "Comedy", Slug = "comedy" },
                new Genre { Id = 4, Name = "Drama", Slug = "drama" },
                new Genre { Id = 5, Name = "Fantasy", Slug = "fantasy" },
                new Genre { Id = 6, Name = "Romance", Slug = "romance" },
                new Genre { Id = 7, Name = "Science Fiction", Slug = "science-fiction" },
                new Genre { Id = 8, Name = "Horror", Slug = "horror" }
            );
        });

        modelBuilder.Entity<ComicGenre>(entity =>
        {
            entity.HasKey(x => new { x.ComicId, x.GenreId });

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.ComicGenres)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Genre)
                .WithMany(x => x.ComicGenres)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(x => x.Name).IsUnique();
            entity.HasIndex(x => x.Slug).IsUnique();
        });

        modelBuilder.Entity<ComicTag>(entity =>
        {
            entity.HasKey(x => new { x.ComicId, x.TagId });

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.ComicTags)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Tag)
                .WithMany(x => x.ComicTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(x => new { x.ComicId, x.CreatedAt });

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasIndex(x => new { x.ComicId, x.UserId }).IsUnique();

            entity.ToTable(table => table.HasCheckConstraint(
                "CK_Ratings_Value", "[Value] >= 1 AND [Value] <= 5"));

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.User)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasIndex(x => new { x.UserId, x.ComicId }).IsUnique();

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.User)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ReadingProgress>(entity =>
        {
            entity.HasIndex(x => new { x.UserId, x.ComicId }).IsUnique();

            entity.HasOne(x => x.Comic)
                .WithMany(x => x.ReadingProgresses)
                .HasForeignKey(x => x.ComicId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Chapter)
                .WithMany()
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.User)
                .WithMany(x => x.ReadingProgresses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(x => new { x.UserId, x.IsRead, x.CreatedAt });

            entity.HasOne(x => x.User)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
