using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Dictionaries.Queries;
using Wordschatz.Application.Dictionaries.Queries.Validators;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Queries.Handlers
{
    public class DictionaryGetManyQueryHandler : IQueryHandler<DictionaryGetManyQuery, List<Dictionary>>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<DictionaryGetManyQuery> _validator;
        public DictionaryGetManyQueryHandler(WordschatzContext dbContext, IValidator<DictionaryGetManyQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public List<Dictionary> Execute(DictionaryGetManyQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var result = _validator.Validate(query);

            if (!result.IsValid)
                return null;

            List<Dictionary> dict = (from d in _dbContext.Dictionaries select d).ToList();
            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;
            dict.Where(d => d.Visibility == Visibility.Public).Skip(skipNum).Take(query.Amount);

            return dict;
        }
    }
}
