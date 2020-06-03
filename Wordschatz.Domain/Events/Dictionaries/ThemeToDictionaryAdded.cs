using Wordschatz.Common.Events;
using MTheme = Wordschatz.Domain.Models.Themes.Theme;

namespace Wordschatz.Domain.Events.Dictionaries
{
    public class ThemeToDictionaryAdded : IEvent
    {
        public ulong Id { get; }
        public MTheme Theme { get; }

        public ThemeToDictionaryAdded(ulong id, MTheme theme)
        {
            Id = id;
            Theme = theme;
        }
    }
}