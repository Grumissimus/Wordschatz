using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Application.ReadModels
{
    /// <summary>
    /// The real model for the dictionary domain model.
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
