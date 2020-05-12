using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.ValueObjects;

namespace Wordschatz.Domain.Tests.ThemeBuilderTests
{
    public class ThemeBuilderTests
    {
        private ThemeBuilder builder;
        private Dictionary mockDictionary;

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
            Assert.Throws<ArgumentException>(() => builder.Build());
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThemeBuilder_SetName_Negative(string name)
        {
            Assert.Throws<ArgumentException>(() => builder.SetName(name));
        }

        [Test]
        public void ThemeBuilder_SetName_ThrowsArgumentExceptionIfTheNameIsLongerThenMaximumAmountOfCharacter()
        {
            Assert.Throws<ArgumentException>(
                () => builder.SetName(new string('*', Name.MaximumLength + 1))
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