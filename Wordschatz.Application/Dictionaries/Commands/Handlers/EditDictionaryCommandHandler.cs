using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Application.Dictionaries.Commands.Validators;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    public class EditDictionaryCommandHandler : ICommandHandler<EditDictionaryCommand>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<EditDictionaryCommand> _validator;

        public EditDictionaryCommandHandler(WordschatzContext dbContext, IValidator<EditDictionaryCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(EditDictionaryCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                return;
            }

            Dictionary oldDict = _dbContext.Dictionaries.Find(command.DictionaryId);

            if(oldDict != null)
                _dbContext.Dictionaries.Remove(oldDict);

            Dictionary newDict = new DictionaryBuilder()
                .SetId(command.DictionaryId)
                .SetName(command.Name)
                .SetDescription(command.Description)
                .SetVisibility(command.VisibilityLevel)
                .SetEditPermissionLevel(command.EditPermission)
                .SetPassword(command.Password)
                .Build();

            _dbContext.Dictionaries.Add(newDict);
            _dbContext.SaveChanges();
        }
    }
}
