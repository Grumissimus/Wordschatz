using FluentValidation;
using System;
using Wordschatz.Application.Dictionaries.Commands.Validators;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    public class CreateDictionaryCommandHandler : ICommandHandler<CreateDictionaryCommand>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<CreateDictionaryCommand> _validator;

        public CreateDictionaryCommandHandler(WordschatzContext dbContext, IValidator<CreateDictionaryCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(CreateDictionaryCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                return;
            }

            Dictionary newDict = new DictionaryBuilder()
                .SetName(command.Name)
                .SetDescription(command.Description)
                .SetVisibility(command.VisibilityLevel)
                .SetEditPermissionLevel(command.EditPermission)
                .SetPassword(command.Password)
                .Build();

            _dbContext.Dictionaries.Add(newDict);
            _dbContext.SaveChanges();

            command.DictionaryId = newDict.Id;
        }
    }
}
