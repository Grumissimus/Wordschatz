using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models
{
    /// <summary>
    /// An associative entity between a mark and a word.
    /// </summary>
    public class MarkWord
    {
        public int MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public int WordId { get; set; }
        public virtual Word Word { get; set; }
    }
}
