using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Application.Queries.Dictionaries
{
    /// <summary>
    /// The real model for the dictionary domain model.
    /// </summary>
    public class DictionaryReadModel
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
