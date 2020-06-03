using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Infrastructure.Configuration
{
    public class WordEntityConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(word => word.Id);

            builder.Property(word => word.Term)
                .IsRequired();

            builder.Property(word => word.Meaning)
                .IsRequired();

            builder.HasOne(word => word.Theme)
                .WithMany(t => t.Words)
                .HasForeignKey(w => w.ThemeId)
                .IsRequired();

            builder.ToTable("Words");
        }
    }
}