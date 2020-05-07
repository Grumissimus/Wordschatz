using Wordschatz.Common.Events;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Domain.Events.Dictionaries
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