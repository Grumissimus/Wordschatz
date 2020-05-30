using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Application.Themes.Queries;
using Wordschatz.Infrastructure.Context;
using System.Linq;

namespace Wordschatz.Application.Themes.QueryHandlers
{
    public class ThemeGetByIdQueryHandler : IQueryHandler<ThemeGetByIdQuery, Theme>
    {
        private readonly WordschatzContext _dbContext;

        public ThemeGetByIdQueryHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
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
