using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Infrastructure.Context
{
    public class WordschatzContext : DbContext
    {
        protected WordschatzContext()
        {
        }

        public WordschatzContext(DbContextOptions<WordschatzContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                t => t.Namespace == "Wordschatz.Infrastructure.Configuration"
            );
        }

        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}