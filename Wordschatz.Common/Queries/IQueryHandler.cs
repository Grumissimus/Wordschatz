namespace Boekje.Domain.Common.Queries
{
    internal interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}