using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class CreateWordCommand : ICommand
    {
        public string Term { get; protected set; }
        public string Meaning { get; protected set; }
        public long ThemeId { get; protected set; }
        public long DictionaryId { get; protected set; }

        public CreateWordCommand(string term, string meaning, long themeId, long dictionaryId)
        {
            Term = term;
            Meaning = meaning;
            ThemeId = themeId;
            DictionaryId = dictionaryId;
        }
    }
}