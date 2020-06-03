using FluentValidation;
using System.Collections.Generic;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Results;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Common
{
    public abstract class CommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        protected readonly WordschatzContext _dbContext;
        protected readonly IValidator<T> _validator;
        protected IResult _result;

        public CommandHandler(WordschatzContext dbContext, IValidator<T> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Validate(T command)
        {
            if (command == null)
            {
                _result = new InvalidResult().WithError($"The command {nameof(T)} has been passed as null");
                return;
            }

            var validationResult = _validator.Validate(command);

            if (!validationResult.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                _result = new InvalidResult(errors);
                return;
            }
        }

        public abstract void Handle(T command);

        public IResult Execute(T command)
        {
            /*** 
             * The null assignment is done here, because command handlers are declared as
             * life-time scoped objects. If it weren't be assigned to null, API would stop
             * working properly after the first request, because the object would still have
             * the result of previous request.
            ***/
            _result = null;

            Validate(command);
            if (_result != null) return _result;
            Handle(command);
            return _result;
        }
    }
}