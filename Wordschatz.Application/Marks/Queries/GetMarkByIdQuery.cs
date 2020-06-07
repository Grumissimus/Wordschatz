using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Marks;

namespace Wordschatz.Application.Marks.Queries
{
    public class GetMarkByIdQuery : IQuery<Mark>
    {
        public long DictionaryId { get; set; }
        public long Id { get; set; }

        public GetMarkByIdQuery(long dictid, long id)
        {
            DictionaryId = dictid;
            Id = id;
        }
    }
}
