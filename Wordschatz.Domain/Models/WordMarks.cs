using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models
{
    /// <summary>
    /// An associative entity between a mark and a word.
    /// </summary>
    public class WordMarks
    {
        public ulong MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public ulong WordId { get; set; }
        public virtual Word Word { get; set; }

        public WordMarks()
        {
        }

        public WordMarks(Mark mark, Word word)
        {
            Mark = mark;
            MarkId = mark.Id;
            Word = word;
            WordId = word.Id;
        }
    }
}