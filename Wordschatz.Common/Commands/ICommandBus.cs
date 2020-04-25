using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Common.Commands
{
    public interface ICommandBus
    {
        void Send<T>(T Command) where T : ICommand;
    }
}
