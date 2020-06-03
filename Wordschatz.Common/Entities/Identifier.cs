using System;
using System.Collections.Generic;

namespace Wordschatz.Common.Entities
{
    public class Identifier : ValueObject
    {
        public long Id { get; set; }

        public Identifier(long id)
        {
            if (id < 0)
                throw new ArgumentException("The identifier cannot be a negative number.");

            Id = id;
        }

        public static implicit operator long(Identifier id) => id.Id;

        public static implicit operator Identifier(long id) => new Identifier(id);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}