using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Application.Words.Queries
{
    public class GetManyWordQuery : IQuery<List<Word>>
    {
        public int Amount { get; set; }
        public int PageNum { get; set; }

        public GetManyWordQuery(int amount, int pageNum)
        {
            Amount = amount;
            PageNum = pageNum;
        }
    }
}
