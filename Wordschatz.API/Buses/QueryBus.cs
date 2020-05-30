using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordschatz.Common.Queries;

namespace Wordschatz.API.Buses
{
    public class QueryBus : IQueryBus
    {
        public TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = IoC.Container.Resolve < IQueryHandler<TQuery, TResult> >();
            return handler.Execute(query);
        }
    }
}
