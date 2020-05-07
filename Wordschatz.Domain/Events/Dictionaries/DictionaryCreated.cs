using Wordschatz.Common.Events;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Events.Dictionaries {
    public class DictionaryCreated : IEvent
    {
        public readonly ulong Id;
        public readonly IDictionary Dictionary;

        public DictionaryCreated(ulong id, IDictionary dict)
        {
            Id = id;
            Dictionary = dict;
        }
    }
}