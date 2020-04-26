using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class DictionaryDescription : ValueObject
    {
        public string Value { get; protected set; }
        public static readonly int MaximumLength = 255;

        private DictionaryDescription(string description)
        {
            Value = description;
        }

        public static DictionaryDescription For(string description)
        {
            if (description == null)
                throw new ArgumentException("The dictionary description must be in a human readable format.");

            if (description.Length > MaximumLength)
                throw new ArgumentException($"The dictionary description cannot be longer than {MaximumLength} characters.");

            return new DictionaryDescription(description);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
