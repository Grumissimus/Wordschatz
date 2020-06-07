using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Marks.Commands.Handlers
{
    public class CreateMarkCommandHandler : CommandHandler<CreateMarkCommand>
    {
        public CreateMarkCommandHandler(WordschatzContext dbContext, IValidator<CreateMarkCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(CreateMarkCommand command)
        {
            Dictionary dict = _dbContext.Dictionaries.Find(command.DictionaryId);

            if (dict == null)
                _result = new InvalidResult()
                    .WithError("No dictionary of this id has been found.");

            Mark newMark = new Mark(command.Name, command.Description, dict);

            _dbContext.Marks.Add(newMark);
            _dbContext.SaveChanges();
            _result = new SuccessResult();

            command.Id = newMark.Id;
        }
    }
}