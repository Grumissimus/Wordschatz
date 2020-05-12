using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.ValueObjects;

namespace Wordschatz.Infrastructure.Configuration
{
	public class MarkEntityConfiguration : IEntityTypeConfiguration<Mark>
	{
		public void Configure(EntityTypeBuilder<Mark> builder)
		{
			builder.HasKey(dict => dict.Id);

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

			builder.OwnsOne(dict => dict.Description,
				desc =>
				{
					desc.Property(d => d.Value)
					.HasColumnName("Description")
					.HasMaxLength(Description.MaximumLength)
					.HasDefaultValue("");
				}
			);

			builder.ToTable("Marks");
		}
	}
}

