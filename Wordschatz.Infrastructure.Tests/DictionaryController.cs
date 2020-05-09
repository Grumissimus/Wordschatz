using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;
using System.Linq;
using System.Collections.Generic;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Infrastructure.Tests
{
    public class DictionaryControllerTest
    {
        private readonly WordschatzContext _context;
        [SetUp]
        public void Setup()
        {
        }

        private WordschatzContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<WordschatzContext>()
                 .UseInMemoryDatabase(databaseName: "WordschatzDatabase")
                 .Options;

            WordschatzContext context = new WordschatzContext(options);

            return context;
        }

        private void SeedDictionary(WordschatzContext context)
        {
            Dictionary[] dicts = new[]{
                new DictionaryBuilder().SetName("German")
                .SetDescription("German-English Dictionary")
                .Build(),
                new DictionaryBuilder().SetName("French")
                .SetDescription("French-English Dictionary")
                .Build(),
                new DictionaryBuilder().SetName("Russian")
                .SetDescription("Russian-English Dictionary")
                .Build(),
                new DictionaryBuilder().SetName("Polski")
                .SetDescription("Słownik języka polskiego")
                .Build()
            };
            context.Dictionaries.AddRange(dicts);
            context.SaveChanges();
        }

        private void SeedTheme(WordschatzContext context)
        {
            Theme[] themes = new[]{
                new ThemeBuilder().SetName("Die Natur")
                .SetDictionary( context.Dictionaries.Find((ulong)1) )
                .SetParent(null)
                .Build(),
                new ThemeBuilder().SetName("Die Einkäufe")
                .SetDictionary( context.Dictionaries.Find((ulong)1) )
                .SetParent(null)
                .Build(),
                new ThemeBuilder().SetName("Aendern mich!")
                .SetDictionary( context.Dictionaries.Find((ulong)1) )
                .SetParent(null)
                .Build(),
                new ThemeBuilder().SetName("Die Tiere")
                .SetDictionary( context.Dictionaries.Find((ulong)1) )
                .SetParent( context.Themes.FirstOrDefault(t => t.Name.Value == "Die Natur") )
                .Build()
            };
            context.Themes.AddRange(themes);
            context.SaveChanges();
        }

        [Test]
        public void Intrastructure_ResourceDb_CreateDictionary()
        {
            var context = CreateContext();
            Dictionary[] dicts = new[]{
                new DictionaryBuilder().SetName("German")
                .SetDescription("German-English Dictionary")
                .Build(),
                new DictionaryBuilder().SetName("French")
                .SetDescription("French-English Dictionary")
                .Build(),
                new DictionaryBuilder().SetName("Russian")
                .SetDescription("Russian-English Dictionary")
                .Build(),
                new DictionaryBuilder().SetName("Polski")
                .SetDescription("Słownik języka polskiego")
                .Build()
            };
            context.Dictionaries.AddRange(dicts);
            context.SaveChanges();

            var count = (from d in context.Dictionaries select d).ToList().Count();
            Assert.AreEqual(4, count);
        }

        [Test]
        public void Intrastructure_ResourceDb_UpdateDictionary()
        {
            var context = CreateContext();
            SeedDictionary(context);

            string newName = "Deutsch";

            var newDict = context.Dictionaries.FirstOrDefault(d => d.Name.Value == "German");
            Assert.IsNotNull(newDict);

            newDict.ChangeName(newName);
            context.Dictionaries.Update(newDict);
            context.SaveChanges();
            
            Assert.IsNotNull(context.Dictionaries.FirstOrDefault(d => d.Name.Value == "Deutsch"));
        }

        [Test]
        public void Intrastructure_ResourceDb_RemoveDictionary()
        {
            var context = CreateContext();
            SeedDictionary(context);

            var newDict = context.Dictionaries.Find((ulong)3);
            context.Dictionaries.Remove(newDict);
            context.SaveChanges();

            Assert.AreEqual(3, (from d in context.Dictionaries select d).ToList().Count());
        }

        [Test]
        public void Intrastructure_ResourceDb_CreateTheme()
        {
            var context = CreateContext();
            SeedDictionary(context);
            SeedTheme(context);

            var count = (from d in context.Themes select d).ToList().Count();
            Assert.AreEqual(4, count);
        }

        [Test]
        public void Intrastructure_ResourceDb_RenameTheme()
        {
            string newThemeName = "Die Pflanzen";
            var context = CreateContext();
            SeedDictionary(context);
            SeedTheme(context);

            var theme = context.Themes.FirstOrDefault(t => t.Name.Value == "Aendern mich!");
            Assert.IsNotNull(theme);

            theme.ChangeName(newThemeName);
            context.Themes.Update(theme);
            context.SaveChanges();

            Assert.IsNotNull(context.Themes.FirstOrDefault(d => d.Name.Value == "Die Pflanzen"));
            Assert.IsNull(context.Themes.FirstOrDefault(d => d.Name.Value == "Aendern mich!"));
        }

        [Test]
        public void Intrastructure_ResourceDb_RemoveTheme()
        {
        }

    }
}