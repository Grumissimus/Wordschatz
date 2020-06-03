using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models;

namespace Wordschatz.Infrastructure.Configuration
{
    public class ThemeMarksEntityConfiguration : IEntityTypeConfiguration<ThemeMarks>
    {
        public void Configure(EntityTypeBuilder<ThemeMarks> builder)
        {
            builder.HasKey(a => new { a.ThemeId, a.MarkId });

            builder.HasOne(b => b.Theme)
                .WithMany(a => a.Marks)
                .HasForeignKey(b => b.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Mark)
                .WithMany(b => b.Themes)
                .HasForeignKey(a => a.MarkId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ThemeMarks");
        }
    }
}