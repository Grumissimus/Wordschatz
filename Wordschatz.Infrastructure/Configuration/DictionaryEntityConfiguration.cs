using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.ValueObjects;

namespace Wordschatz.Infrastructure.Configuration
{
    public class DictionaryEntityConfiguration : IEntityTypeConfiguration<Dictionary>
    {
        public void Configure(EntityTypeBuilder<Dictionary> builder)
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

            builder.Property(dict => dict.EditPermission)
                .HasDefaultValue(EditPermission.OnlyCreator);

            builder.Property(dict => dict.Visibility)
                .HasDefaultValue(Visibility.Public);

            builder.OwnsOne(dict => dict.Password,
                desc =>
                {
                    desc.Property(d => d.Salt)
                    .HasColumnName("Salt")
                    .HasMaxLength(Password.SaltLength)
                    .HasDefaultValue(null);

                    desc.Property(d => d.Hash)
                    .HasColumnName("Hash")
                    .HasMaxLength(Password.HashLength)
                    .HasDefaultValue(null);
                }
            );

            builder.HasMany(dict => dict.Themes)
                .WithOne(theme => theme.Dictionary)
                .HasForeignKey(theme => theme.DictionaryId);

            builder.ToTable("Dictionary");
        }
    }
}