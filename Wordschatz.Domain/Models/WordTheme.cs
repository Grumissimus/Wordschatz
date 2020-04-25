using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    public class WordTheme
    {
        public int WordId { get; set; }
        public virtual Word Word { get; set; }
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
