using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class DeleteWordCommand : ICommand
    {
        public long Id { get; set; }
        public long ThemeId { get; protected set; }
        public long DictionaryId { get; protected set; }

        public DeleteWordCommand()
        {

        }

        public DeleteWordCommand(long id, long themeId, long dictionaryId)
        {
            Id = id;
            ThemeId = themeId;
            DictionaryId = dictionaryId;
        }
    }
}