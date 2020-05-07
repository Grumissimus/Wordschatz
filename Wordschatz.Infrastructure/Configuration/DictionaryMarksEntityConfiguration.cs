using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models;

namespace Wordschatz.Infrastructure.Configuration
{
	public class DictionaryMarksEntityConfiguration : IEntityTypeConfiguration<DictionaryMarks>
	{
		public void Configure(EntityTypeBuilder<DictionaryMarks> builder)
		{
            builder.HasKey(a => new { a.DictionaryId, a.MarkId });

            builder.HasOne(b => b.Dictionary)
                .WithMany(a => a.Marks)
                .HasForeignKey(b => b.DictionaryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Mark)
                .WithMany(b => b.Dictionaries)
                .HasForeignKey(a => a.MarkId)
                .OnDelete(DeleteBehavior.Restrict);

			builder.ToTable("DictionaryMarks");
		}
	}
}

