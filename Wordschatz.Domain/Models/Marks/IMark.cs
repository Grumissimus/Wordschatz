using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Marks
{
    public interface IMark
    {
        void ChangeName(string name);

        void ChangeDescription(string description);

        void AddWord(Word word);

        void AddTheme(Theme theme);
    }
}