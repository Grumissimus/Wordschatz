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
        public ulong MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public ulong WordId { get; set; }
        public virtual Word Word { get; set; }
    }
}
