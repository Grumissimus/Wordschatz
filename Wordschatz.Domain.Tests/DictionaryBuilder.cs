using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Tests.DictionaryBuilderTests
{
    public class DictionaryBuilderTests
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
                () => builder.SetName(new string('*', Name.MaximumLength + 1) )
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
                () => builder.SetDescription(new string('*', Description.MaximumLength + 1))
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentNullException_IfTheThemeIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => builder.AddTheme(null)
            );
        }

        [Test]
        public void DictionaryBuilder_ThrowsArgumentNullException_IfTheTagIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(
                () => builder.AddTag(null)
            );
        }

        [Test]
        public void DictionaryBuilder_ReturnsDictionaryWithDefaultValues()
        {
            Dictionary dict = builder
                .SetName("Test Dictionary")
                .SetDescription("Dictionary used in testing")
                .Build();
            
            Assert.IsInstanceOf<Dictionary>(dict);
            Assert.AreEqual(dict.Name.Value, "Test Dictionary");
            Assert.AreEqual(dict.Description.Value, "Dictionary used in testing");
            Assert.AreEqual(dict.Visibility, Visibility.Public);
            Assert.AreEqual(dict.EditPermission, EditPermission.OnlyCreator);
        }
    }
}