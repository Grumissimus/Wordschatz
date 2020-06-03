using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Words.Commands.Handlers
{
    public class CreateWordCommandHandler : CommandHandler<CreateWordCommand>
    {
        public CreateWordCommandHandler(WordschatzContext dbContext, IValidator<CreateWordCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(CreateWordCommand command)
        {
            Theme theme = (from d in _dbContext.Themes
                           where d.Id == command.ThemeId && d.DictionaryId == command.DictionaryId
                           select d).SingleOrDefault();

            if (theme == null)
            {
                _result = new InvalidResult().WithError("No theme of this id has been found.");
                return;
            }

            Word newWord = new Word(command.Term, command.Meaning, theme);

            _dbContext.Words.Add(newWord);
            _dbContext.SaveChanges();

            _result = new SuccessResult();
        }
    }
}