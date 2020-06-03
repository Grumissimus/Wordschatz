using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Queries.Handlers
{
    public class ThemeGetManyQueryHandler : QueryHandler<ThemeGetManyQuery, List<Theme>>
    {
        public ThemeGetManyQueryHandler(WordschatzContext dbContext, IValidator<ThemeGetManyQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(ThemeGetManyQuery query)
        {
            List<Theme> themes = (from d in _dbContext.Themes where d.DictionaryId == query.DictionaryId select d).ToList();
            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;

            themes.Skip(skipNum).Take(query.Amount);

            _result = new SuccessResult<List<Theme>>(themes);
        }
    }
}