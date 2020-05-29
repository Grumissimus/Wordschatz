using System;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.CommandHandlers
{
    public class EditDictionaryCommandHandler : ICommandHandler<EditDictionaryCommand>
    {
        private readonly WordschatzContext _dbContext;

        public EditDictionaryCommandHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
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
                .SetVisibility(command.VisibilityLevel)
                .SetEditPermissionLevel(command.EditPermission)
                .SetPassword(command.Password)
                .Build();

            _dbContext.Dictionaries.Update(newDict);
            _dbContext.SaveChanges();
        }
    }
}
