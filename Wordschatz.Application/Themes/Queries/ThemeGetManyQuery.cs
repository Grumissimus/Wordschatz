using System.Collections.Generic;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Application.Themes.Queries
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