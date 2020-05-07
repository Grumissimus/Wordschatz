namespace Wordschatz.Common.Commands
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;
    }
}