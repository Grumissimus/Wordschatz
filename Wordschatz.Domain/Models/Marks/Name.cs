﻿using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Marks
{
    public class Name : ValueObject
    {
        public string Value { get; }
        public static readonly int MaximumLength = 64;

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The mark's name must be in a human readable format.");

            if (name.Length > MaximumLength)
                throw new ArgumentException($"The mark's name cannot be longer than {MaximumLength} characters.");

            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}