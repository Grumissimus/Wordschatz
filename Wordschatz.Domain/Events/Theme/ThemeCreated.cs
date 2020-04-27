using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Dictionary
{
    public class ThemeCreated : IEvent
    {
        public readonly ulong Id;
        public readonly ulong DictionaryId;
        public readonly string Name;

        public ThemeCreated(ulong id, ulong dictId, string name)
        {
            Id = id;
            DictionaryId = dictId;
            Name = name;
        }
    }
}
