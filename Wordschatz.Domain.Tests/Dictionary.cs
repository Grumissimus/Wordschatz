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
        public void DictionaryBuilder_ThrowsArgumentExceptionIfUserTriesToBuildWithoutSetName()
        {
            Assert.Throws<ArgumentNullException>( () => builder.Build() );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentExceptionIfTheNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(null));
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentExceptionIfTheNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(""));
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentExceptionIfTheNameIsLongerThenMaximumAmountOfCharacter()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetName(new string('*', DictionaryName.MaximumLength + 1) )
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentExceptionIfTheDescriptionIsNull()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetDescription(null)
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentExceptionIfTheDescriptionIsLongerThanMaximumAmoungOfCharacter()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetDescription(new string('*', DictionaryDescription.MaximumLength + 1))
            );
        }
    }
}