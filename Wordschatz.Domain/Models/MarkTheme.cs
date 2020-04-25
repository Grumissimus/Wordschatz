using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models
{
    public class MarkTheme
    {
        public ulong MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public ulong ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
