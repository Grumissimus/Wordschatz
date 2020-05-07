using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Themes;
using Name = Wordschatz.Domain.Models.Themes.Name;

namespace Wordschatz.Infrastructure.Configuration
{
	public class ThemeEntityConfiguration : IEntityTypeConfiguration<Theme>
	{
		public void Configure(EntityTypeBuilder<Theme> builder)
		{
			builder.HasKey(theme => theme.Id);

			builder.OwnsOne(dict => dict.Name,
				name =>
				{
					name.Property(n => n.Value)
					.HasColumnName("Name")
					.HasMaxLength(Name.MaximumLength)
					.IsRequired()
					.HasDefaultValue("");
				}
			);

			builder.HasOne(theme => theme.Dictionary)
				.WithMany(dict => dict.Themes)
				.HasForeignKey(theme => theme.DictionaryId)
				.IsRequired();

			builder.HasOne(theme => theme.Parent)
				.WithOne()
				.HasForeignKey<Theme>(theme => theme.ParentId)
				.IsRequired(false);

			builder.HasMany(theme => theme.Words)
				.WithOne(words => words.Theme)
				.HasForeignKey(word => word.ThemeId)
				.IsRequired();

			builder.ToTable("Themes");
		}
	}
}

