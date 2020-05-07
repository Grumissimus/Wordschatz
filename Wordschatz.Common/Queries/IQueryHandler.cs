namespace Wordschatz.Common.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}