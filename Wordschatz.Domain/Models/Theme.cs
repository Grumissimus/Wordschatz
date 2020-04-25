using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    public class Theme : EventSourcedAggregate
    {
        public string Name { get; set; }
        public ulong DictionaryId { get; set; }
        public virtual Dictionary Dictionary { get; set; }
        public ulong? ParentId { get; set; }
        public virtual Theme Parent { get; set; }

        public virtual List<WordTheme> Words { get; set; }
        public virtual List<MarkTheme> Marks { get; set; }
    }
}
