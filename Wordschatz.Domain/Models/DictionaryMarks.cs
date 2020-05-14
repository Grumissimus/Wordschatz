﻿using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;

namespace Wordschatz.Domain.Models
{
    public class DictionaryMarks
    {
        public long MarkId { get; set; }
        public virtual Mark Mark { get; set; }
        public long DictionaryId { get; set; }
        public virtual Dictionary Dictionary { get; set; }

        public DictionaryMarks()
        {
        }

        public DictionaryMarks(Mark mark, Dictionary dict)
        {
            MarkId = mark.Id;
            Mark = mark;
            DictionaryId = dict.Id;
            Dictionary = dict;
        }
    }
}