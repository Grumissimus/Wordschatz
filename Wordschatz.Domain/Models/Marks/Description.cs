using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Marks
{
    public class Description : ValueObject
    {
        public string Value { get; }
        public static readonly int MaximumLength = 255;

        public Description(string description)
        {
            if (description == null)
                throw new ArgumentException("The mark's description cannot be null.");

            if (description.Length > MaximumLength)
                throw new ArgumentException($"The mark's description cannot be longer than {MaximumLength} characters.");

            Value = description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}