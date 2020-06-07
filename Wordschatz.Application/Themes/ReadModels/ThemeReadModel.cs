using System.Collections.Generic;
using Wordschatz.Application.Common;

namespace Wordschatz.Application.Themes.ReadModels
{
    public class ThemeReadModel : IReadModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int WordCount { get; set; }
        public long? ParentId { get; set; }
        public List<string> Marks { get; set; }
    }
}