using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Common.Queries;

namespace Wordschatz.Application.Dictionaries.Queries
{
    public class DictionaryGetByIdQuery : IQuery<Dictionary>
    {
        public long Id { get; set; }
        public DictionaryGetByIdQuery(long id)
        {
            Id = id;
        }
    }
}
