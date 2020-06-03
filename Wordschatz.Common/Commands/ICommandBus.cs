using Wordschatz.Common.Results;

namespace Wordschatz.Common.Commands
{
    public interface ICommandBus
    {
        IResult Send<T>(T command) where T : ICommand;
    }
}