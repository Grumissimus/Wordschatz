using FluentValidation;
using System;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Words.Commands.Handlers
{
    public class DeleteWordCommandHandler : CommandHandler<DeleteWordCommand>
    {
        public DeleteWordCommandHandler(WordschatzContext dbContext, IValidator<DeleteWordCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(DeleteWordCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = _validator.Validate(command);

            if (!result.IsValid) return;

            Theme theme = (from d in _dbContext.Themes
                           where d.Id == command.ThemeId && d.DictionaryId == command.DictionaryId
                           select d).SingleOrDefault();

            Word word = (from d in _dbContext.Words
                         where d.Id == command.Id && d.ThemeId == theme.Id
                         select d).SingleOrDefault();

            _dbContext.Words.Remove(word);
            _dbContext.SaveChanges();
        }
    }
}