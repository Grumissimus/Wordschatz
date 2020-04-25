using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boekje.Domain.Common.Queries
{
    interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}
