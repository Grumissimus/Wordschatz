using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Dictionaries
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