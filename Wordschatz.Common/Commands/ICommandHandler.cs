using Wordschatz.Common.Results;

namespace Wordschatz.Common.Commands
{
    // <summary>
    // A non-generic interface of command handler used to register
    // </summary>
    public interface ICommandHandler { }

    public interface ICommandHandler<in T> where T : ICommand
    {
        IResult Execute(T command);
    }
}