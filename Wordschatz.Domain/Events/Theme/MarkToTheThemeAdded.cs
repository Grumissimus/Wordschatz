using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Events.Theme
{
    class MarkToTheThemeAdded
    {
        public readonly ulong ThemeId;
        public readonly ulong MarkId;
        public MarkToTheThemeAdded(ulong themeId, ulong markId)
        {
            ThemeId = themeId;
            MarkId = markId;
        }
    }
}
