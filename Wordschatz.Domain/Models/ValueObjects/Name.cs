﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; private set; }
        public static int MaximumLength { get; private set; } = 80;

        private Name()
        {
        }

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name is nullable or contains whitespace characters (e.g. space, tab, new line).");

            if (Regex.Match(name, $"[\x0-\x1F\x7F\x8E-\x9F]").Success)
                throw new ArgumentException("The name contains unprintable characters.");

            if (name.Length > MaximumLength)
                throw new ArgumentException($"The name is longer than {MaximumLength} characters.");

            Value = name;
        }

        public static implicit operator string(Name n) => n.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}