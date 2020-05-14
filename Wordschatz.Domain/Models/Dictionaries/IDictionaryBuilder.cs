using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public interface IDictionaryBuilder
    {
        IDictionaryBuilder SetId(long id);
        IDictionaryBuilder SetName(string name);
        IDictionaryBuilder SetDescription(string description);
        IDictionaryBuilder SetVisibility(Visibility visibility);
        IDictionaryBuilder SetEditPermissionLevel(EditPermission permissionLevel);
        IDictionaryBuilder SetPassword(string password);
        IDictionaryBuilder AddTheme(Theme theme);
        IDictionaryBuilder AddMark(Mark mark);
        Dictionary Build();
    }
}