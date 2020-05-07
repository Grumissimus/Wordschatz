namespace Wordschatz.Common.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
    }
}