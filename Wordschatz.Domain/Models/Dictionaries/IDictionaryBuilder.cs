using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public interface IDictionaryBuilder
    {
        IDictionaryBuilder SetId(ulong id);
        IDictionaryBuilder SetName(string name);
        IDictionaryBuilder SetDescription(string description);
        IDictionaryBuilder SetVisibility(Visibility visibility);
        IDictionaryBuilder SetEditPermissionLevel(EditPermission permissionLevel);
        IDictionaryBuilder AddTheme(Theme theme);
        IDictionaryBuilder AddTag(Tag tag);
        Dictionary Build();
    }
}
