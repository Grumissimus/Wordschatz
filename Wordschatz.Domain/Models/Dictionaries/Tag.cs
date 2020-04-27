using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Tag : ValueObject
    {
        public string Name { get; }
        public static readonly int MaximumLength = 64;

        public Tag(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentNullException("The tag must be in a human readable format.");

            if (tagName.Length > MaximumLength)
                throw new ArgumentException($"The tag cannot be longer than {MaximumLength} characters.");

            Name = tagName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
