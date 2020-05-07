using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Theme
{
    public class ThemeRenamed : IEvent
    {
        public readonly ulong Id;
        public readonly string NewName;

        public ThemeRenamed(ulong id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}