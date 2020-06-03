using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public interface IDictionary
    {
        public void ChangeName(string newName);

        public void AddMark(Mark mark);

        public void RemoveMark(Mark mark);

        public void AddTheme(Theme theme);

        public void RemoveTheme(Theme theme);
    }
}