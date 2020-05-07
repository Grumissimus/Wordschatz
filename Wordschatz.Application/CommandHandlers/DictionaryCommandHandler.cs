using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;
using Wordschatz.Application.Commands.Dictionaries;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;
using Wordschatz.Application.Interfaces;

namespace Wordschatz.Application.CommandHandlers
{
    public class DictionaryCommandHandler : ICommandHandler<CreateDictionaryCommand>, 
        ICommandHandler<EditDictionaryCommand>, 
        ICommandHandler<DeleteDictionaryCommand>,
        ICommandHandlerService
    {
        private readonly WordschatzContext _dbContext;

        public DictionaryCommandHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(CreateDictionaryCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            Dictionary newDict = new DictionaryBuilder()
                .SetName(command.Name)
                .SetDescription(command.Description)
                .SetVisibility(command.Visibility)
                .SetEditPermissionLevel(command.EditPermission)
                .SetPassword(command.Password)
                .Build();

            _dbContext.Dictionaries.AddAsync(newDict);
            _dbContext.SaveChanges();
        }

        public void Execute(EditDictionaryCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (command.DictionaryId <= 0)
                throw new ArgumentException("Id must be a positive number bigger than zero.");

            Dictionary newDict = new DictionaryBuilder()
                .SetId(command.DictionaryId)
                .SetName(command.Name)
                .SetDescription(command.Description)
                .SetVisibility(command.Visibility)
                .SetEditPermissionLevel(command.EditPermission)
                .SetPassword(command.Password)
                .Build();

            _dbContext.Dictionaries.Update(newDict);
            _dbContext.SaveChanges();
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
