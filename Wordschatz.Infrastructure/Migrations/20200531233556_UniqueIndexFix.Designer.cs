﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Infrastructure.Migrations
{
    [DbContext(typeof(WordschatzContext))]
    [Migration("20200531233556_UniqueIndexFix")]
    partial class UniqueIndexFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wordschatz.Domain.Models.Dictionaries.Dictionary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EditPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Visibility")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.HasKey("Id");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.DictionaryMarks", b =>
                {
                    b.Property<long>("DictionaryId")
                        .HasColumnType("bigint");

                    b.Property<long>("MarkId")
                        .HasColumnType("bigint");

                    b.HasKey("DictionaryId", "MarkId");

                    b.HasIndex("MarkId");

                    b.ToTable("DictionaryMarks");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Marks.Mark", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.ThemeMarks", b =>
                {
                    b.Property<long>("ThemeId")
                        .HasColumnType("bigint");

                    b.Property<long>("MarkId")
                        .HasColumnType("bigint");

                    b.HasKey("ThemeId", "MarkId");

                    b.HasIndex("MarkId");

                    b.ToTable("ThemeMarks");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Themes.Theme", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DictionaryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DictionaryId");

                    b.HasIndex("ParentId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.WordMarks", b =>
                {
                    b.Property<long>("WordId")
                        .HasColumnType("bigint");

                    b.Property<long>("MarkId")
                        .HasColumnType("bigint");

                    b.HasKey("WordId", "MarkId");

                    b.HasIndex("MarkId");

                    b.ToTable("WordMarks");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Words.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Meaning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Term")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ThemeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Dictionaries.Dictionary", b =>
                {
                    b.OwnsOne("Wordschatz.Domain.Models.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<long>("DictionaryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(400)")
                                .HasMaxLength(400)
                                .HasDefaultValue("");

                            b1.HasKey("DictionaryId");

                            b1.ToTable("Dictionary");

                            b1.WithOwner()
                                .HasForeignKey("DictionaryId");
                        });

                    b.OwnsOne("Wordschatz.Domain.Models.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("DictionaryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(80)")
                                .HasMaxLength(80)
                                .HasDefaultValue("");

                            b1.HasKey("DictionaryId");

                            b1.ToTable("Dictionary");

                            b1.WithOwner()
                                .HasForeignKey("DictionaryId");
                        });

                    b.OwnsOne("Wordschatz.Domain.Models.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<long>("DictionaryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Hash")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Hash")
                                .HasColumnType("nvarchar(256)")
                                .HasMaxLength(256)
                                .HasDefaultValue(null);

                            b1.Property<byte[]>("Salt")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Salt")
                                .HasColumnType("varbinary(256)")
                                .HasMaxLength(256)
                                .HasDefaultValue(null);

                            b1.HasKey("DictionaryId");

                            b1.ToTable("Dictionary");

                            b1.WithOwner()
                                .HasForeignKey("DictionaryId");
                        });
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.DictionaryMarks", b =>
                {
                    b.HasOne("Wordschatz.Domain.Models.Dictionaries.Dictionary", "Dictionary")
                        .WithMany("Marks")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Wordschatz.Domain.Models.Marks.Mark", "Mark")
                        .WithMany("Dictionaries")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Marks.Mark", b =>
                {
                    b.OwnsOne("Wordschatz.Domain.Models.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<long>("MarkId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(400)")
                                .HasMaxLength(400)
                                .HasDefaultValue("");

                            b1.HasKey("MarkId");

                            b1.ToTable("Marks");

                            b1.WithOwner()
                                .HasForeignKey("MarkId");
                        });

                    b.OwnsOne("Wordschatz.Domain.Models.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("MarkId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(80)")
                                .HasMaxLength(80)
                                .HasDefaultValue("");

                            b1.HasKey("MarkId");

                            b1.ToTable("Marks");

                            b1.WithOwner()
                                .HasForeignKey("MarkId");
                        });
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.ThemeMarks", b =>
                {
                    b.HasOne("Wordschatz.Domain.Models.Marks.Mark", "Mark")
                        .WithMany("Themes")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Wordschatz.Domain.Models.Themes.Theme", "Theme")
                        .WithMany("Marks")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Themes.Theme", b =>
                {
                    b.HasOne("Wordschatz.Domain.Models.Dictionaries.Dictionary", "Dictionary")
                        .WithMany("Themes")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Wordschatz.Domain.Models.Themes.Theme", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Wordschatz.Domain.Models.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("ThemeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(80)")
                                .HasMaxLength(80)
                                .HasDefaultValue("");

                            b1.HasKey("ThemeId");

                            b1.ToTable("Themes");

                            b1.WithOwner()
                                .HasForeignKey("ThemeId");
                        });
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.WordMarks", b =>
                {
                    b.HasOne("Wordschatz.Domain.Models.Marks.Mark", "Mark")
                        .WithMany("Words")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Wordschatz.Domain.Models.Words.Word", "Word")
                        .WithMany("Marks")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Wordschatz.Domain.Models.Words.Word", b =>
                {
                    b.HasOne("Wordschatz.Domain.Models.Themes.Theme", "Theme")
                        .WithMany("Words")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
