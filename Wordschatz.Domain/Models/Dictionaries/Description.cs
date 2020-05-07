using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Description : ValueObject
    {
        public string Value { get; private set; }
        public static readonly int MaximumLength = 255;

        private Description()
        {

        }

        public Description(string description)
        {
            if (description == null)
                throw new ArgumentException("The dictionary description cannot be null.");

            if (description.Length > MaximumLength)
                throw new ArgumentException($"The dictionary description cannot be longer than {MaximumLength} characters.");

            Value = description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}