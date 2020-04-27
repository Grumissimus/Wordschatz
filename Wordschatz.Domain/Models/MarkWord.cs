using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Words;

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

        public MarkWord()
        {

        }

        public MarkWord(Mark mark, Word word)
        {
            Mark = mark;
            MarkId = mark.Id;
            Word = word;
            WordId = word.Id;
        }
    }
}
