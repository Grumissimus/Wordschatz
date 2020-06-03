using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Queries.Handlers
{
    public class ThemeGetByIdQueryHandler : QueryHandler<ThemeGetByIdQuery, Theme>
    {
        public ThemeGetByIdQueryHandler(WordschatzContext dbContext, IValidator<ThemeGetByIdQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(ThemeGetByIdQuery query)
        {
            Theme theme = (from t in _dbContext.Themes
                           where t.Id == query.Id && t.DictionaryId == query.DictionaryId
                           select t).SingleOrDefault();

            _result = new SuccessResult<Theme>(theme);
        }
    }
}