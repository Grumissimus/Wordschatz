using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; private set; }

        private Name()
        {
        }

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name must be in a human readable format.");

            Value = name;
        }

        public static implicit operator string(Name n) => n.Value;
        public static implicit operator Name(string name) => new Name(name);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}