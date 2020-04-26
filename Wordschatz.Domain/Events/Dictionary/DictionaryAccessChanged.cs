using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Events;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Events.Dictionary
{
    public class DictionaryAccessChanged : IEvent
    {
        public readonly ulong Id;
        public readonly Visibility NewAccessLevel;

        public DictionaryAccessChanged(ulong id, Visibility newAccessLevel)
        {
            Id = id;
            NewAccessLevel = newAccessLevel;
        }
    }
}
