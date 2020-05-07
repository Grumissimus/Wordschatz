using System.Threading.Tasks;

namespace Boekje.Domain.Common.Queries
{
    internal interface IQueryBus
    {
        Task<TResult> Send<TQuery, TResult>(TQuery Command) where TQuery : IQuery<TResult>;
    }
}