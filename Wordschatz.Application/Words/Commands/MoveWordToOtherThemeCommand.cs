using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class MoveWordToOtherThemeCommand : ICommand
    {
        public long Id { get; set; }
        public long ThemeId { get; set; }
        public long DictionaryId { get; protected set; }

        public MoveWordToOtherThemeCommand(long id, long themeId)
        {
            Id = id;
            ThemeId = themeId;
        }
    }
}