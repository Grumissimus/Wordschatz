using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class DictionaryName : ValueObject
    {
        public string Value { get; protected set; }
        public static readonly int MaximumLength = 64;

        private DictionaryName(string name)
        {
            Value = name;
        }

        public static DictionaryName For(string name){
            if( string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The dictionary name must be in a human readable format.");

            if ( name.Length > MaximumLength)
                throw new ArgumentException($"The dictionary name cannot be longer than {MaximumLength} characters.");

            return new DictionaryName(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
