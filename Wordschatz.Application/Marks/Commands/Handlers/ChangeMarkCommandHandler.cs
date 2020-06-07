using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Application.Marks.Commands;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Marks.Commands.Handlers
{
    public class ChangeMarkCommandHandler : CommandHandler<ChangeMarkCommand>
    {
        public ChangeMarkCommandHandler(WordschatzContext dbContext, IValidator<ChangeMarkCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(ChangeMarkCommand command)
        {
            Mark mark = _dbContext.Marks.Find(command.Id);

            if (mark == null)
                _result = new InvalidResult()
                    .WithError("No mark of this id has been found.");

            mark.ChangeName(command.Name);
            mark.ChangeDescription(command.Description);

            _dbContext.Marks.Update(mark);
            _dbContext.SaveChanges();
            _result = new SuccessResult();
        }
    }
}