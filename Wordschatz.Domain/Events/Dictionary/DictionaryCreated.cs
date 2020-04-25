using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Dictionary
{
    public class DictionaryCreated : IEvent
    {
        public readonly ulong Id;
        public readonly string Name;
        public DictionaryCreated(ulong id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
