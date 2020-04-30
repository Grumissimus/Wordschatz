using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Themes;

using DictionaryName = Wordschatz.Domain.Models.Dictionaries;
using ThemeName = Wordschatz.Domain.Models.Themes.Name;

namespace Wordschatz.Domain.Tests.ThemeBuilderTests
{
    public class ThemeBuilderTests
    {
        ThemeBuilder builder;
        Dictionary mockDictionary;

        [SetUp]
        public void Setup()
        {
            mockDictionary = new DictionaryBuilder()
                .SetId(1)
                .SetName("Mock dictionary")
                .SetDescription("")
                .Build();
            builder = new ThemeBuilder();
        }

        [Test]
        public void ThemeBuilder_Build_ThrowsArgumentExceptionIfUserTriesToBuildWithoutSetName()
        {
            Assert.Throws<ArgumentNullException>( () => builder.Build() );
        }

        [Test]
        public void ThemeBuilder_SetName_ThrowsArgumentExceptionIfTheNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(null));
        }

        [Test]
        public void ThemeBuilder_SetName_ThrowsArgumentExceptionIfTheNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(""));
        }
        
        [Test]
        public void ThemeBuilder_SetName_ThrowsArgumentExceptionIfTheNameIsLongerThenMaximumAmountOfCharacter()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetName(new string('*', ThemeName.MaximumLength + 1))
            );
        }

        [Test]
        public void ThemeBuilder_SetParent_ThrowsArgumentExceptionIfParentIsTheSame()
        {
            Theme temp = new ThemeBuilder().SetId(1).SetName("Theme").SetDictionary(mockDictionary).Build();

            Assert.Throws<ArgumentException>(
                () => builder.SetParent(temp)
            );
        }
    }
}