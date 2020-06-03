using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Commands.Handlers
{
    public class CreateThemeCommandHandler : CommandHandler<CreateThemeCommand>
    {
        public CreateThemeCommandHandler(WordschatzContext dbContext, IValidator<CreateThemeCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(CreateThemeCommand command)
        {
            Dictionary dict = _dbContext.Dictionaries.Find(command.DictionaryId);
            Theme parent = _dbContext.Themes.Find(command.ParentId);

            if (dict == null)
                _result = new InvalidResult()
                    .WithError("No dictionary of this id has been found.");

            Theme newTheme = new ThemeBuilder()
                .SetName(command.Name)
                .SetDictionary(dict)
                .SetParent(parent)
                .Build();

            _dbContext.Themes.Add(newTheme);
            _dbContext.SaveChanges();
            _result = new SuccessResult();

            command.Id = newTheme.Id;
        }
    }
}