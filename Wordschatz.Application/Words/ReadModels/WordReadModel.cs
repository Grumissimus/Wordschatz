using System.Collections.Generic;
using Wordschatz.Application.Common;

namespace Wordschatz.Application.Words.ReadModels
{
    public class WordReadModel : IReadModel
    {
        public long Id { get; set; }
        public string Term { get; set; }
        public string Meaning { get; set; }
        public List<string> Marks { get; set; }
    }
}