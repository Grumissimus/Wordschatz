using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Common.Queries;

namespace Wordschatz.Application.Dictionaries.Queries
{
    public class DictionaryGetManyQuery : IQuery<List<Dictionary>>
    {
        public int Amount { get; set; }
        public int PageNum { get; set; }

        public DictionaryGetManyQuery(int amount, int pageNum)
        {
            Amount = amount;
            PageNum = pageNum;
        }
    }
}
