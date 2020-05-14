using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Themes
{
    public interface IThemeBuilder
    {
        IThemeBuilder SetId(long id);

        IThemeBuilder SetName(string name);

        IThemeBuilder SetDictionary(Dictionary dictionary);

        IThemeBuilder SetParent(Theme parent);

        IThemeBuilder AddWord(Word word);

        IThemeBuilder AddMark(Mark mark);

        Theme Build();
    }
}