using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models
{
    public class ThemeMarks
    {
        public ulong MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public ulong ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

        public ThemeMarks()
        {
        }

        public ThemeMarks(Mark mark, Theme theme)
        {
            MarkId = mark.Id;
            Mark = mark;
            ThemeId = theme.Id;
            Theme = theme;
        }
    }
}