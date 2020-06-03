using System.Collections.Generic;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Application.Words.Queries
{
    public class GetManyWordsQuery : IQuery<List<Word>>
    {
        public long DictionaryId { get; set; }
        public long ThemeId { get; set; }
        public int Amount { get; set; }
        public int PageNum { get; set; }

        public GetManyWordsQuery(long dictionaryId, long themeId, int amount, int pageNum)
        {
            DictionaryId = dictionaryId;
            ThemeId = themeId;
            Amount = amount;
            PageNum = pageNum;
        }
    }
}