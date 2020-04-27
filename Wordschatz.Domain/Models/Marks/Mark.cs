using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Marks
{
    /// <summary>
    /// A mark class.
    /// </summary>
    public class Mark : EventSourcedAggregate, IMark
    {
        public Name Name { get; protected set; }
        public Description Description { get; protected set; }

        public virtual List<MarkWord> Words { get; protected set; }

        public Mark()
        {

        }

        public Mark(ulong id, string name, string description)
        {
            Id = id;
            Name = new Name(name);
            Description = new Description(description);
            Words = new List<MarkWord>();
        }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        public void ChangeDescription(string description)
        {
            Description = new Description(description);
        }

        public void AddWord(Word word)
        {
            if (word == null)
                throw new ArgumentNullException("The word cannot be null.");

            Words.Add(new MarkWord(this, word));
        }
    }
}
