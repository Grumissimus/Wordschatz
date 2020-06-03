using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class DeleteWordCommand : ICommand
    {
        public long DictionaryId { get; protected set; }
        public long ThemeId { get; protected set; }
        public long Id { get; set; }

        public DeleteWordCommand(long id)
        {
            Id = id;
        }
    }
}