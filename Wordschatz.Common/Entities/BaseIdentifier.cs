using System;
using System.Collections.Generic;

namespace Wordschatz.Common.Entities
{
    public class BaseIdentifier : ValueObject
    {
        public ulong Value { get; protected set; }

        private BaseIdentifier(ulong id)
        {
            Value = id;
        }

        public static BaseIdentifier For(ulong id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Base identifier cannot be lower than zero");
            }

            return new BaseIdentifier(id);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}