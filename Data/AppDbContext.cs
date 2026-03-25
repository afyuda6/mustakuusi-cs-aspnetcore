using Microsoft.EntityFrameworkCore;
using mustakuusi_cs_aspnetcore.Models;

namespace mustakuusi_cs_aspnetcore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Screenshot> Screenshots => Set<Screenshot>();
        public DbSet<Character> Characters => Set<Character>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.ImageSrc).HasColumnName("image_src");
                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Detail).HasColumnName("detail");
                entity.Property(e => e.PrivacyPolicyLink).HasColumnName("privacy_policy_link");
                entity.Property(e => e.DownloadLink).HasColumnName("download_link");
                entity.Property(e => e.LongDescription).HasColumnName("long_description");
                entity
                    .Property(e => e.Categories)
                    .HasColumnName("categories")
                    .HasColumnType("text[]");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("characters");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ImageSrc).HasColumnName("image_src");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Position).HasColumnName("position");
            });

            modelBuilder.Entity<GameCharacter>(entity =>
            {
                entity.ToTable("game_characters");
                entity.HasKey(gc => new { gc.GameId, gc.CharacterId });

                entity.Property(gc => gc.GameId).HasColumnName("game_id");
                entity.Property(gc => gc.CharacterId).HasColumnName("character_id");

                entity.HasOne(gc => gc.Game)
                    .WithMany(g => g.GameCharacters)
                    .HasForeignKey(gc => gc.GameId);

                entity.HasOne(gc => gc.Character)
                    .WithMany(c => c.GameCharacters)
                    .HasForeignKey(gc => gc.CharacterId);
            });

            modelBuilder.Entity<Screenshot>(entity =>
            {
                entity.ToTable("screenshots");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ImageSrc).HasColumnName("image_src");
                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.HasOne(s => s.Game)
                    .WithMany(g => g.Screenshots)
                    .HasForeignKey(s => s.GameId);
            });

            modelBuilder.Entity<GameCharacter>()
                .HasKey(gc => new { gc.GameId, gc.CharacterId });

            modelBuilder.Entity<GameCharacter>()
                .HasOne(gc => gc.Game)
                .WithMany(g => g.GameCharacters)
                .HasForeignKey(gc => gc.GameId);

            modelBuilder.Entity<GameCharacter>()
                .HasOne(gc => gc.Character)
                .WithMany(c => c.GameCharacters)
                .HasForeignKey(gc => gc.CharacterId);

            modelBuilder.Entity<Screenshot>()
                .HasOne(s => s.Game)
                .WithMany(g => g.Screenshots)
                .HasForeignKey(s => s.GameId);
        }
    }
}