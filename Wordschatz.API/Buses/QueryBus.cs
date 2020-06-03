using Autofac;
using Wordschatz.Common.Queries;
using Wordschatz.Common.Results;

namespace Wordschatz.API.Buses
{
    public class QueryBus : IQueryBus
    {
        public IResult<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = IoC.Container.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                return (IResult<TResult>)new InvalidResult<TResult>().WithError($"No handler for command {nameof(query)} has been found");
            }
            return handler.Execute(query);
        }
    }
}