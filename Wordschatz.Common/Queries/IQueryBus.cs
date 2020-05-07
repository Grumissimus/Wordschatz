using System.Threading.Tasks;

namespace Wordschatz.Common.Queries
{
    public interface IQueryBus
    {
        Task<TResult> Send<TQuery, TResult>(TQuery Command) where TQuery : IQuery<TResult>;
    }
}