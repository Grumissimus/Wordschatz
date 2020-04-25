using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    /// <summary>
    /// A mark class.
    /// </summary>
    public class Mark : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<MarkWord> Words { get; set; }
    }
}
