using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Words
{
    public interface IWord
    {
        void ChangeTerm(string term);

        void ChangeDefinition(string definition);

        void ChangeTheme(Theme newTheme);

        void AddMark(Mark mark);
    }
}