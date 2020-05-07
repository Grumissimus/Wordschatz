namespace Wordschatz.Domain.Events.Theme
{
    internal class MarkToTheThemeAdded
    {
        public readonly ulong ThemeId;
        public readonly ulong MarkId;

        public MarkToTheThemeAdded(ulong themeId, ulong markId)
        {
            ThemeId = themeId;
            MarkId = markId;
        }
    }
}