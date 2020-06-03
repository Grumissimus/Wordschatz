using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Marks;

namespace Wordschatz.Application.Marks.Queries
{
    class GetMarkByIdQuery : IQuery<Mark>
    {
        public long Id { get; set; }

        public GetMarkByIdQuery(long id)
        {
            Id = id;
        }
    }
}
