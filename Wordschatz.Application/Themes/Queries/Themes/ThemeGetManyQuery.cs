using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Common.Queries;

namespace Wordschatz.Application.Queries.Themes
{
    public class ThemeGetManyQuery : IQuery<List<Theme>>
    {
        public long DictionaryId { get; set; }
        public int Amount { get; set; }
        public int PageNum { get; set; }

        public ThemeGetManyQuery(long did, int amount, int pageNum)
        {
            DictionaryId = did;
            Amount = amount;
            PageNum = pageNum;
        }
    }
}
