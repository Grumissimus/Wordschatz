using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Application.ReadModels
{
    public class ThemeReadModel
    {
        public long Id {get; set;}
        public string Name { get; set; }
        public int WordCount { get; set; }
        public List<long> Children { get; set; }
    }
}
