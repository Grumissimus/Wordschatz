using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Words.Commands.Handlers
{
    public class ChangeWordCommandHandler : CommandHandler<ChangeWordCommand>
    {
        public ChangeWordCommandHandler(WordschatzContext dbContext, IValidator<ChangeWordCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(ChangeWordCommand command)
        {
            Theme theme = (from d in _dbContext.Themes
                           where d.Id == command.ThemeId && d.DictionaryId == command.DictionaryId
                           select d).SingleOrDefault();

            Word word = (from d in _dbContext.Words
                         where d.Id == command.Id && d.ThemeId == command.ThemeId
                         select d).SingleOrDefault();

            word.ChangeTerm(command.Term);
            word.ChangeTerm(command.Meaning);

            _dbContext.Words.Update(word);
            _dbContext.SaveChanges();
        }
    }
}