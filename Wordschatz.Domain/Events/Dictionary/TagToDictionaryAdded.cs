using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Dictionary
{
    public class TagToDictionaryAdded : IEvent
    {
        public readonly ulong Id;
        public readonly string Tag;

        public TagToDictionaryAdded(ulong id, string tag)
        {
            Id = id;
            Tag = tag;
        }
    }
}
