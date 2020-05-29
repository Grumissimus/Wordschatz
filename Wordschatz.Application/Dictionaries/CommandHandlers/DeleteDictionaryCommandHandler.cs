using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.CommandHandlers
{
    public class DeleteDictionaryCommandHandler : ICommandHandler<DeleteDictionaryCommand>
    {
        private readonly WordschatzContext _dbContext;

        public DeleteDictionaryCommandHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(DeleteDictionaryCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            Dictionary dict = _dbContext.Dictionaries.Find(command.Id);

            if (dict == null)
                return;

            _dbContext.Dictionaries.Remove(dict);
            _dbContext.SaveChanges();
        }
    }
}
