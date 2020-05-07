using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;
using System.Linq;
using System.Collections.Generic;

namespace Wordschatz.Infrastructure.Tests
{
    public class Tests
    {
        WordschatzContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WordschatzContext>()
                 .UseInMemoryDatabase(databaseName: "WordschatzDatabase")
                 .Options;

            context = new WordschatzContext(options);
        }


        [Test]
        public void Intrastructure_ResourceDb_CreateDictionary()
        {
            context.Dictionaries.Add(new DictionaryBuilder()
                .SetId(1)
                .SetName("German")
                .SetDescription("German-English Dictionary")
                .Build()
            );

            context.Dictionaries.Add(new DictionaryBuilder()
                .SetId(2)
                .SetName("French")
                .SetDescription("Francais?")
                .Build()
            );

            context.SaveChanges();    

            List<Dictionary> dicts = (from d in context.Dictionaries select d).ToList();

            Assert.AreEqual(2, dicts.Count());
        }

        [Test]
        public void Intrastructure_ResourceDb_UpdateDictionary()
        {
            string oldName = "German";
            string newName = "Deutsch";

            context.Dictionaries.Add(new DictionaryBuilder()
                .SetId(1)
                .SetName(oldName)
                .SetDescription("German-English Dictionary")
                .Build()
            );
            context.SaveChanges();

            var newDict = context.Dictionaries.Find( (ulong)1 );

            Console.WriteLine(newDict);

            newDict.ChangeName(newName);
            context.Dictionaries.Update(newDict);
            context.SaveChanges();
            
            Assert.AreEqual(context.Dictionaries.Find((ulong)1).Name.Value, newName);
        }
    }
}