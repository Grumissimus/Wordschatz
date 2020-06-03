using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Queries.Handlers
{
    public class DictionaryGetManyQueryHandler : QueryHandler<DictionaryGetManyQuery, List<Dictionary>>
    {
        public DictionaryGetManyQueryHandler(WordschatzContext dbContext, IValidator<DictionaryGetManyQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(DictionaryGetManyQuery query)
        {
            List<Dictionary> dict = (from d in _dbContext.Dictionaries select d).ToList();
            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;

            dict.Where(d => d.Visibility == Visibility.Public).Skip(skipNum).Take(query.Amount);

            _result = new SuccessResult<List<Dictionary>>(dict);
        }
    }
}