using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Dictionaries.Queries;
using Wordschatz.Application.Dictionaries.Queries.Validators;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Queries.Handlers
{
    public class DictionaryGetByIdQueryHandler : IQueryHandler<DictionaryGetByIdQuery, Dictionary>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<DictionaryGetByIdQuery> _validator;
        public DictionaryGetByIdQueryHandler(WordschatzContext dbContext, IValidator<DictionaryGetByIdQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }
        public Dictionary Execute(DictionaryGetByIdQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var result = _validator.Validate(query);

            if (!result.IsValid)
            {
                return null;
            }

            Dictionary dict = _dbContext.Dictionaries.Find(query.Id);

            return dict;
        }
    }
}
