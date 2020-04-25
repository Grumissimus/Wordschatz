using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    public class Dictionary : EventSourcedAggregate
    {
        public string Name { get; set; }
        public DictionaryAccess Access { get; set; }
        public virtual List<string> Tags { get; set; }
        public virtual List<Theme> Themes { get; set; }
    }
}
