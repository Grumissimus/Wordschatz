using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Application.Words.Queries
{
    public class GetWordByIdQuery : IQuery<Word>
    {
        public long Id { get; set; }

        public GetWordByIdQuery(long id)
        {
            Id = id;
        }
    }
}
