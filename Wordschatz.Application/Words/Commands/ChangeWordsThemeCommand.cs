using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class ChangeWordsThemeCommand : ICommand
    {
        public long Id { get; set; }
        public long ThemeId { get; set; }
        public ChangeWordsThemeCommand(long id, long themeId)
        {
            Id = id;
            ThemeId = themeId;
        }
    }
}
