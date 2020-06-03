using Wordschatz.Common.Events;
using DictionaryModel = Wordschatz.Domain.Models.Dictionaries.Dictionary;

namespace Wordschatz.Domain.Events.Dictionaries
{
    public class DictionaryCreated : IEvent
    {
        public readonly DictionaryModel Dictionary;

        public DictionaryCreated(DictionaryModel dict)
        {
            Dictionary = dict;
        }
    }
}