using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Marks;

namespace Wordschatz.Application.Marks.Queries
{
    class GetManyMarksQuery : IQuery<Mark>
    {
        public int Amount { get; set; }
        public int PageNum { get; set; }

        public GetManyMarksQuery(int amount, int pageNum)
        {
            Amount = amount;
            PageNum = pageNum;
        }
    }
}
