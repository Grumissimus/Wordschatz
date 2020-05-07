using Wordschatz.Common.Events;

namespace Wordschatz.Domain.Events.Theme
{
    public class ThemeMoved : IEvent
    {
        public readonly ulong Id;
        public readonly ulong? NewParentId;
        public readonly string NewName;

        public ThemeMoved(ulong id, ulong? newParentId, string newName)
        {
            Id = id;
            NewParentId = newParentId;
            NewName = newName;
        }
    }
}