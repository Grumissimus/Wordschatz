using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.API.Buses
{
    public class CommandBus : ICommandBus
    {
        public void Send<T>(T command) where T : ICommand
        {
            var handlers = IoC.Container.Resolve<IEnumerable<ICommandHandler<T>>>().ToList();

            switch(handlers.Count){
                case 0:
                    throw new Exception($"Command does not have any handler {command.GetType().Name}");
                case 1:
                    handlers[0].Execute(command);
                    break;
                default:
                    throw new Exception($"Too many registred handlers - {handlers.Count} for command {command.GetType().Name}");
            };
        }
    }
}
