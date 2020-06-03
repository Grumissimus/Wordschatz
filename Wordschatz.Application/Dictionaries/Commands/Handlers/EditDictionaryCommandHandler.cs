using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    public class EditDictionaryCommandHandler : CommandHandler<EditDictionaryCommand>
    {
        public EditDictionaryCommandHandler(WordschatzContext dbContext, IValidator<EditDictionaryCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(EditDictionaryCommand command)
        {
            Dictionary oldDict = _dbContext.Dictionaries.Find(command.DictionaryId);

            if (oldDict != null)
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