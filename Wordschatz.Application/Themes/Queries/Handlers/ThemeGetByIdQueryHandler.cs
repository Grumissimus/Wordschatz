using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Application.Themes.Queries;
using Wordschatz.Infrastructure.Context;
using System.Linq;
using FluentValidation;

namespace Wordschatz.Application.Themes.Queries.Handlers
{
    public class ThemeGetByIdQueryHandler : IQueryHandler<ThemeGetByIdQuery, Theme>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<ThemeGetByIdQuery> _validator;

        public ThemeGetByIdQueryHandler(WordschatzContext dbContext, IValidator<ThemeGetByIdQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Theme Execute(ThemeGetByIdQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            Theme theme = (from t in _dbContext.Themes
                          where t.Id == query.Id && t.DictionaryId == query.DictionaryId
                          select t).Single();

            return theme;
        }
    }
}
