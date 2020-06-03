using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Themes.Commands
{
    public class DeleteThemeCommand : ICommand
    {
        public long Id { get; set; }
        public long DictionaryId { get; set; }

        public DeleteThemeCommand(long id, long did)
        {
            Id = id;
            DictionaryId = did;
        }
    }
}