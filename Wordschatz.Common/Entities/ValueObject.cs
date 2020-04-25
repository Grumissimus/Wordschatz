using System;
using System.Collections.Generic;
using System.Linq;

namespace Wordschatz.Common.Entities
{
    /// <summary>
    /// A base class for value objects.
    /// </summary>
    /// The code is made by Steven Roberts and is found in Vladimir Khorikov's blog: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != this.GetType()) return false;

            var that = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(that.GetEqualityComponents());
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
        }
        public static bool operator ==(ValueObject a, ValueObject b)
        {
            return a is null && b is null ? a.Equals(b) : false;
        }
        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}
