using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Themes
{
    public interface ITheme
    {
        void ChangeName(string newName);
        void MoveToOtherDictionary(Dictionary newDictionary);
        void ChangeParent(Theme newParent);
        void AddWord(Word word);
        void AddMark(Mark mark);
    }
}