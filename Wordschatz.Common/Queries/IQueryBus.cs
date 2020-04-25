using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boekje.Domain.Common.Queries
{
    interface IQueryBus
    {
        Task<TResult> Send<TQuery, TResult>(TQuery Command) where TQuery : IQuery<TResult>;
    }
}
