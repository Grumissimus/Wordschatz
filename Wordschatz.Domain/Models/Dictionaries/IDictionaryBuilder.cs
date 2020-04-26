using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public interface IDictionaryBuilder
    {
        IDictionaryBuilder SetName(string name);
        IDictionaryBuilder SetDescription(string description);
        IDictionaryBuilder SetVisibility(Visibility visibility);
        IDictionaryBuilder SetEditPermissionLevel(EditPermission permissionLevel);
        IDictionaryBuilder AddTheme(Theme theme);
        IDictionaryBuilder AddTag(string tag);
        Dictionary Build();
    }
}
