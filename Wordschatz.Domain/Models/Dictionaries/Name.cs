﻿using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Name : ValueObject
    {
        public string Value { get; private set; }
        public static readonly int MaximumLength = 64;

        private Name()
        {

        }

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The dictionary name must be in a human readable format.");

            if (name.Length > MaximumLength)
                throw new ArgumentException($"The dictionary name cannot be longer than {MaximumLength} characters.");

            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}