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
            var handlers = IoC.Container.Resolve<IEnumerable<IQueryHandler<TQuery,TResult>>>().ToList();

            return handlers.Count switch
            {
                0 => throw new Exception($"Query does not have any handler {query.GetType().Name}"),
                1 => handlers[0].Execute(query),
                _ => throw new Exception($"Too many registred handlers - {handlers.Count} for query {query.GetType().Name}"),
            };
            ;
        }
    }
}
