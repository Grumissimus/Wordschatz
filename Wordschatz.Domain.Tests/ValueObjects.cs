using NUnit.Framework;
using System;
using Wordschatz.Domain.Models.ValueObjects;

namespace Wordschatz.Domain.Tests.ValueObjects
{
    internal class ValueObjectsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Name")]
        [TestCase("Extremely Long Name")]
        [TestCase("123456")]
        public void Name_Positive(string name)
        {
            Name myName = new Name(name);
            Assert.AreEqual( (string)myName, name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\n\t\n\t")]
        [TestCase("        ")]
        public void Name_Negative(string name)
        {
            Assert.Throws<ArgumentException>(() => new Name(name));
        }

        [TestCase("Description")]
        [TestCase("Very long description")]
        [TestCase("")]
        public void Description_Positive(string desc)
        {
            Description description = new Description(desc);
            Assert.AreEqual((string)description, desc);
        }

        [TestCase(null)]
        public void Description_Negative(string desc)
        {
            Assert.Throws<ArgumentException>(() => new Description(desc));
        }

        [TestCase("mySecretPassword")]
        public void Password_Initialize_Positive(string pass)
        {
            Password password = pass;
            Assert.AreEqual(Password.SaltLength, password.Salt.Length);
            byte[] myHash = Convert.FromBase64String(password.Hash);
            Assert.AreEqual(Password.SaltLength + Password.HashLength, myHash.Length);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\n\t\n\t")]
        [TestCase("        ")]
        public void Password_Initialize_Negative(string pass)
        {
            Assert.Throws<ArgumentException>(() => new Password(pass));
        }

        [Test]
        public void Password_CorrectPassword()
        {
            Password pass = "mySecretPassword";

            Assert.IsTrue( pass.ValidatePassword("mySecretPassword") );
        }

        [Test]
        public void Password_IncorrectPassword()
        {
            Password pass = "mySecretPassword";

            Assert.IsFalse(pass.ValidatePassword("mySecretIncorrectPassword"));
        }
    }
}