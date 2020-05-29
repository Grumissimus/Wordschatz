using System.Threading.Tasks;

namespace Wordschatz.Common.Queries
{
    public interface IQueryBus
    {
        TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}