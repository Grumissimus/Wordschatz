using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    public class Word : Entity
    {
        public string Term { get; set; }
        public string Meaning { get; set; }

        public virtual List<WordTheme> Themes { get; set; }
        public virtual List<MarkWord> Marks { get; set; }
    }
}
