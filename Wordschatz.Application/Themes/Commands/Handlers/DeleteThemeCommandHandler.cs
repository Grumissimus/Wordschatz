using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Commands.Handlers
{
    public class DeleteThemeCommandHandler : CommandHandler<DeleteThemeCommand>
    {
        public DeleteThemeCommandHandler(WordschatzContext dbContext, IValidator<DeleteThemeCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(DeleteThemeCommand command)
        {
            Theme theme = (from t in _dbContext.Themes
                           where t.Id == command.Id && t.DictionaryId == command.DictionaryId
                           select t).SingleOrDefault();

            if (theme == null)
                _result = new InvalidResult()
                    .WithError("No theme of this id has been found.");

            foreach(Word word in theme.Words)
            {
                _dbContext.Words.Remove(word);
            }

            _dbContext.Themes.Remove(theme);
            _dbContext.SaveChanges();
            _result = new SuccessResult();
        }
    }
}