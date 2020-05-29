using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Application.ReadModels
{
    class WordReadModel
    {
        public long Id { get; set; }
        public string Term { get; set; }
        public string Meaning { get; set; }
        public int Theme { get; set; }
        public List<string> Marks {get; set;}
    }
}
