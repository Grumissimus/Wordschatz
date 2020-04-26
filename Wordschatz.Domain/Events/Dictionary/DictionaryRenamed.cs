﻿using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Dictionary
{
    public class DictionaryRenamed : IEvent
    {
        public readonly ulong Id;
        public readonly string NewName;

        public DictionaryRenamed(ulong id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}