using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Themes
{
    public interface ITheme
    {
        void AddWord(Word word);

        void AddMark(Mark mark);
    }
}