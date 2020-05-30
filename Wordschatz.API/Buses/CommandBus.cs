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
            var handler = IoC.Container.Resolve<ICommandHandler<T>>();
            handler.Execute(command);
        }
    }
}
