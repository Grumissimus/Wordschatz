using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Marks;

namespace Wordschatz.Application.Marks.Queries
{
    public class GetManyMarksQuery : IQuery<List<Mark>>
    {
        public long DictionaryId { get; set; }
        public int Amount { get; set; }
        public int PageNum { get; set; }

        public GetManyMarksQuery(long dictionaryId, int amount, int pageNum)
        {
            DictionaryId = dictionaryId;
            Amount = amount;
            PageNum = pageNum;
        }
    }
}
