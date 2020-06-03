using System.Collections.Generic;

namespace Wordschatz.Application.Words.ReadModels
{
    public class WordReadModel
    {
        public long Id { get; set; }
        public string Term { get; set; }
        public string Meaning { get; set; }
        public List<string> Marks { get; set; }
    }
}