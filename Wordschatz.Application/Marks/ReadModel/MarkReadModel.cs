using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Common;

namespace Wordschatz.Application.Marks.ReadModel
{
    public class MarkReadModel : IReadModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
