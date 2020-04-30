using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Tests.DictionaryTests
{
    class DictionaryTests
    {
        Dictionary dictionary;

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
