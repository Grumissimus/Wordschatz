using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Dictionaries
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