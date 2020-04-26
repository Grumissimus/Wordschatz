using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Tests
{
    public class Tests
    {
        DictionaryBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DictionaryBuilder();
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentException_IfUserTriesToBuildWithoutSetName()
        {
            Assert.Throws<ArgumentNullException>( () => builder.Build() );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentException_IfTheNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(null));
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentException_IfTheNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(""));
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentException_IfTheNameIsLongerThenMaximumAmountOfCharacter()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetName(new string('*', DictionaryName.MaximumLength + 1) )
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentException_IfTheDescriptionIsNull()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetDescription(null)
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentException_IfTheDescriptionIsLongerThanMaximumAmountOfCharacter()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetDescription(new string('*', DictionaryDescription.MaximumLength + 1))
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentNullException_IfTheThemeIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => builder.AddTheme(null)
            );
        }
    }
}