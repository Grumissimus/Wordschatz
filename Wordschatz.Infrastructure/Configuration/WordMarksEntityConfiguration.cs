using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models;

namespace Wordschatz.Infrastructure.Configuration
{
	public class WordMarksEntityConfiguration : IEntityTypeConfiguration<WordMarks>
	{
		public void Configure(EntityTypeBuilder<WordMarks> builder)
		{
            builder.HasKey(a => new { a.WordId, a.MarkId });

            builder.HasOne(b => b.Word)
                .WithMany(a => a.Marks)
                .HasForeignKey(b => b.WordId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Mark)
                .WithMany(b => b.Words)
                .HasForeignKey(a => a.MarkId)
                .OnDelete(DeleteBehavior.Restrict);

			builder.ToTable("WordMarks");
		}
	}
}

