using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Common.Queries;

namespace Wordschatz.Application.Queries.Dictionaries
{
    public class DictionaryGetByIdQuery : IQuery<Dictionary>
    {
        public uint Id { get; set; }
        public DictionaryGetByIdQuery(uint id)
        {
            Id = id;
        }
    }
}
