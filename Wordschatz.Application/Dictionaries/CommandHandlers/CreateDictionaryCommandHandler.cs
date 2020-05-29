using System;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.CommandHandlers
{
    public class CreateDictionaryCommandHandler : ICommandHandler<CreateDictionaryCommand>
    {
        private readonly WordschatzContext _dbContext;

        public CreateDictionaryCommandHandler(WordschatzContext dbContext)
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

            _dbContext.Dictionaries.Add(newDict);
            _dbContext.SaveChanges();

            command.DictionaryId = newDict.Id;
        }
    }
}
