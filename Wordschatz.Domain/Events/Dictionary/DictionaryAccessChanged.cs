using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Events;
using Wordschatz.Domain.Models;

namespace Wordschatz.Domain.Events.Dictionary
{
    public class DictionaryAccessChanged : IEvent
    {
        public readonly ulong Id;
        public readonly DictionaryAccess NewAccessLevel;

        public DictionaryAccessChanged(ulong id, DictionaryAccess newAccessLevel)
        {
            Id = id;
            NewAccessLevel = newAccessLevel;
        }
    }
}
