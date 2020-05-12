using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.ValueObjects
{
    public class Description : ValueObject
    {
        public string Value { get; private set; }
        public static int MaximumLength { get; private set; } = 400;

        private Description()
        {
        }

        public Description(string description)
        {
            if (description == null)
                throw new ArgumentException("The description is null.");

            if (Regex.Match(description, $"[\x0-\x1F\x7F\x8E-\x9F]").Success)
                throw new ArgumentException("The name contains unprintable characters.");

            if (description.Length > MaximumLength)
                throw new ArgumentException($"The name is longer than {MaximumLength} characters.");

            Value = description;
        }

        public static implicit operator string(Description n) => n.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}