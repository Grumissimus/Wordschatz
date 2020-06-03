using Wordschatz.Common.Results;

namespace Wordschatz.Common.Queries
{
    public interface IQueryBus
    {
        IResult<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}