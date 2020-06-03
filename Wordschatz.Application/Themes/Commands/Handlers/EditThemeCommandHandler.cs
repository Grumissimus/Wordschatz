using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Commands.Handlers
{
    public class EditThemeCommandHandler : CommandHandler<EditThemeCommand>
    {
        public EditThemeCommandHandler(WordschatzContext dbContext, IValidator<EditThemeCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(EditThemeCommand command)
        {
            Theme themeToChange = _dbContext.Themes.Find(command.Id);

            if (themeToChange == null)
                _result = new InvalidResult()
                    .WithError("No theme of this id has been found.");

            Theme parent = _dbContext.Themes.Find(command.ParentId);

            themeToChange.ChangeName(command.Name);
            themeToChange.ChangeParent(parent);

            _dbContext.Themes.Update(themeToChange);
            _dbContext.SaveChanges();
            _result = new SuccessResult();
        }
    }
}