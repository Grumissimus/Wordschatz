using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class ChangeWordCommand : ICommand
    {
        public long DictionaryId { get; set; }
        public long ThemeId { get; set; }
        public long Id { get; set; }
        public string Term { get; protected set; }
        public string Meaning { get; protected set; }

        public ChangeWordCommand()
        {

        }

        public ChangeWordCommand(long id, string term, string meaning)
        {
            Id = id;
            Term = term;
            Meaning = meaning;
        }
    }
}