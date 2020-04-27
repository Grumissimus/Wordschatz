using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models
{
    public class MarkTheme
    {
        public ulong MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public ulong ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

        public MarkTheme()
        {

        }

        public MarkTheme(Mark mark, Theme theme)
        {
            MarkId = mark.Id;
            Mark = mark;
            ThemeId = theme.Id;
            Theme = theme;
        }
    }
}
