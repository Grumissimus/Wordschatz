using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Dictionaries.Commands
{
    public class DeleteDictionaryCommand : ICommand
    {
        public long Id { get; set; }

        public DeleteDictionaryCommand()
        {
        }

        public DeleteDictionaryCommand(long id)
        {
            Id = id;
        }
    }
}