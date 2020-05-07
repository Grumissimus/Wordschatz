using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Tests.DictionaryTests
{
    internal class DictionaryTests
    {
        private Dictionary dictionary;

        [SetUp]
        public void Setup()
        {
            dictionary = new DictionaryBuilder()
                .SetName("Test Dictionary")
                .SetDescription("Dictionary existing for testing basic dictionary methods.")
                .Build();
        }

        [Test]
        public void Dictionary_AddTheme_ThrowsArgumentNullExceptionIfWordIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => dictionary.AddTheme(null)
            );
        }
    }
}