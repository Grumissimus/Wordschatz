using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    public class Dictionary : Entity
    {
        public string Name { get; set; }
        public virtual List<Theme> Themes { get; set; }
    }
}
