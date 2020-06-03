using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    public class CreateDictionaryCommandHandler : CommandHandler<CreateDictionaryCommand>
    {
        public CreateDictionaryCommandHandler(WordschatzContext dbContext, IValidator<CreateDictionaryCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(CreateDictionaryCommand command)
        {
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
            _result = new SuccessResult();
        }
    }
}