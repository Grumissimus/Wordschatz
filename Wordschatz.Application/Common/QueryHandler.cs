using FluentValidation;
using System.Collections.Generic;
using Wordschatz.Common.Queries;
using Wordschatz.Common.Results;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Common
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected readonly WordschatzContext _dbContext;
        protected readonly IValidator<TQuery> _validator;
        protected IResult<TResult> _result;

        public QueryHandler(WordschatzContext dbContext, IValidator<TQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Validate(TQuery query)
        {
            if (query == null)
            {
                _result = (IResult<TResult>)new InvalidResult<TResult>()
                    .WithError($"The query {nameof(TQuery)} has been passed as null");
                return;
            }

            var validationResult = _validator.Validate(query);

            if (!validationResult.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                _result = new InvalidResult<TResult>(errors);

                return;
            }
        }

        public abstract void Handle(TQuery query);

        public IResult<TResult> Execute(TQuery query)
        {
            /*** 
             * The null assignment is done here, because command handlers are declared as
             * life-time scoped objects. If it weren't be assigned to null, API would stop
             * working properly after the first request, because the object would still have
             * the result of previous request.
            ***/
            _result = null;

            Validate(query);
            if (_result != null) return _result;
            Handle(query);
            return _result;
        }
    }
}