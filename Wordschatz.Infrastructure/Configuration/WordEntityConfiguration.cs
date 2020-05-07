using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Infrastructure.Configuration
{
	public class WordEntityConfiguration : IEntityTypeConfiguration<Word>
	{
		public void Configure(EntityTypeBuilder<Word> builder)
		{
			builder.ToTable("Words");
		}
	}
}

