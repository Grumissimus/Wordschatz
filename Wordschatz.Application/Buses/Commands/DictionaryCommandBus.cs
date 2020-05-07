using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.CommandHandlers;
using Wordschatz.Application.Commands.Dictionaries;
using Wordschatz.Common.Commands;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Buses.Commands
{
    class DictionaryCommandBus : ICommandBus
    {
        private readonly DictionaryCommandHandler _dictionaryCommandHandler;
        public DictionaryCommandBus(WordschatzContext dbContext)
        {
            _dictionaryCommandHandler = new DictionaryCommandHandler(dbContext);
        }

        public void Send<T>(T command) where T : ICommand
        {
        }
    }
}
