using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FeelMusic.Models
{
    public partial class CornHacks2019DBContext : DbContext
    {
        public CornHacks2019DBContext()
        {
        }

        public CornHacks2019DBContext(DbContextOptions<CornHacks2019DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8PJNIFB;Initial Catalog=CornHacks2019DB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.IdVideo);

                entity.HasIndex(e => new { e.Title, e.VideoUrl })
                    .HasName("UC_Video")
                    .IsUnique();

                entity.Property(e => e.IdVideo).HasColumnName("idVideo");

                entity.Property(e => e.Anger).HasColumnName("anger");

                entity.Property(e => e.Disgust).HasColumnName("disgust");

                entity.Property(e => e.Fear).HasColumnName("fear");

                entity.Property(e => e.Joy).HasColumnName("joy");

                entity.Property(e => e.Sadness).HasColumnName("sadness");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.VideoUrl)
                    .IsRequired()
                    .HasColumnName("videoUrl")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
