using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Marks.Commands.Handlers
{
    public class DeleteMarkCommandHandler : CommandHandler<DeleteMarkCommand>
    {
        public DeleteMarkCommandHandler(WordschatzContext dbContext, IValidator<DeleteMarkCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(DeleteMarkCommand command)
        {
            Mark mark = (from t in _dbContext.Marks
                           where t.Id == command.Id && t.DictionaryId == command.DictionaryId
                           select t).SingleOrDefault();

            if (mark == null)
                _result = new InvalidResult()
                    .WithError("No theme of this id has been found.");

            _dbContext.Marks.Remove(mark);
            _dbContext.SaveChanges();
            _result = new SuccessResult();
        }
    }
}