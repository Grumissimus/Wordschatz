using Autofac;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Results;

namespace Wordschatz.API.Buses
{
    public class CommandBus : ICommandBus
    {
        public IResult Send<T>(T command) where T : ICommand
        {
            var handler = IoC.Container.Resolve<ICommandHandler<T>>();

            if (handler == null)
            {
                return new InvalidResult().WithError($"No handler for command {nameof(command)} has been found");
            }

            return handler.Execute(command);
        }
    }
}