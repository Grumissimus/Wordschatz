using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models
{
    public class MarkTheme
    {
        public int MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
