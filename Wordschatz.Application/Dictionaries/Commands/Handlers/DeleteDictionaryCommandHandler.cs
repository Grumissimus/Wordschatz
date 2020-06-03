using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    public class DeleteDictionaryCommandHandler : CommandHandler<DeleteDictionaryCommand>
    {
        public DeleteDictionaryCommandHandler(WordschatzContext dbContext, IValidator<DeleteDictionaryCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(DeleteDictionaryCommand command)
        {
            Dictionary dict = _dbContext.Dictionaries.Find(command.Id);

            if (dict == null)
            {
                _result = new InvalidResult()
                    .WithError("No dictionary of this id has been found");
                return;
            }

            _dbContext.Dictionaries.Remove(dict);
            _dbContext.SaveChanges();
            _result = new SuccessResult();
        }
    }
}