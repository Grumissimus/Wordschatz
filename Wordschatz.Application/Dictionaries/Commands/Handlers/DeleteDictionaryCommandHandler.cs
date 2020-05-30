using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Application.Dictionaries.Commands.Validators;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    public class DeleteDictionaryCommandHandler : ICommandHandler<DeleteDictionaryCommand>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<DeleteDictionaryCommand> _validator;

        public DeleteDictionaryCommandHandler(WordschatzContext dbContext, IValidator<DeleteDictionaryCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(DeleteDictionaryCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                return;
            }

            Dictionary dict = _dbContext.Dictionaries.Find(command.Id);

            if (dict == null)
                return;

            _dbContext.Dictionaries.Remove(dict);
            _dbContext.SaveChanges();
        }
    }
}
