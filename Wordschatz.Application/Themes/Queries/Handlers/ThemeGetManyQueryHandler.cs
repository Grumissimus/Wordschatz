using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Application.Themes.Queries;
using Wordschatz.Infrastructure.Context;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Wordschatz.Application.Themes.Queries.Handlers
{
    public class ThemeGetManyQueryHandler : IQueryHandler<ThemeGetManyQuery, List<Theme>>
    {
        private readonly WordschatzContext _dbContext;
        private readonly IValidator<ThemeGetManyQuery> _validator;

        public ThemeGetManyQueryHandler(WordschatzContext dbContext, IValidator<ThemeGetManyQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public List<Theme> Execute(ThemeGetManyQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            List<Theme> dict = (from d in _dbContext.Themes where d.DictionaryId == query.DictionaryId select d).ToList();
            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;
            dict.Skip(skipNum).Take(query.Amount);

            return dict;
        }
    }
}
