using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Words.Commands
{
    public class CreateWordCommand : ICommand
    {
        public string Term { get; protected set; }
        public string Meaning { get; protected set; }

        public CreateWordCommand(string term, string meaning)
        {
            Term = term;
            Meaning = meaning;
        }
    }
}
