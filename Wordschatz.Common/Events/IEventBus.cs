using System.Threading.Tasks;

namespace Wordschatz.Common.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}