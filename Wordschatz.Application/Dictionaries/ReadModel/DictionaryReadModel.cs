using System.Collections.Generic;

namespace Wordschatz.Application.Dictionaries.ReadModels
{
    /// <summary>
    /// The read model of dictionary.
    /// </summary>
    public class DictionaryReadModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Marks { get; set; }
        public int ThemeCount { get; set; }
    }
}