using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class CreateWordCommand : ICommand
    {
        public string Term { get; set; }
        public string Meaning { get; set; }
        public long ThemeId { get; set; }
        public long DictionaryId { get; set; }

        //Output value
        public long Id { get; protected set; }

        public CreateWordCommand()
        {

        }

        public CreateWordCommand(string term, string meaning, long themeId, long dictionaryId)
        {
            Term = term;
            Meaning = meaning;
            ThemeId = themeId;
            DictionaryId = dictionaryId;
        }
    }
}