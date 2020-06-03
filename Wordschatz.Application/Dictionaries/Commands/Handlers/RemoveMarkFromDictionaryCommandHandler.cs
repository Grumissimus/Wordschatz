using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Commands.Handlers
{
    class RemoveMarkFromDictionaryCommandHandler : CommandHandler<RemoveMarkFromDictionaryCommand>
    {
        public RemoveMarkFromDictionaryCommandHandler(WordschatzContext dbContext, IValidator<RemoveMarkFromDictionaryCommand> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(RemoveMarkFromDictionaryCommand command)
        {
            Mark mark = _dbContext.Marks.Find(command.MarkId);
            Dictionary dictionary = _dbContext.Dictionaries.Find(command.DictionaryId);

            if (mark == null)
            {
                _result = new InvalidResult().WithError("No mark of this id has been found"); 
                return;
            }

            if (dictionary == null)
            {
                _result = new InvalidResult().WithError("No dictionary of this id has been found"); 
                return;
            }

            dictionary.RemoveMark(mark);
            _dbContext.SaveChanges();

            _result = new SuccessResult();
        }
    }
}
