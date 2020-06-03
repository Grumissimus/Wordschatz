using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Words.Queries.Handlers
{
    public class GetManyWordQueryHandler : QueryHandler<GetManyWordsQuery, List<Word>>
    {
        public GetManyWordQueryHandler(WordschatzContext dbContext, IValidator<GetManyWordsQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(GetManyWordsQuery query)
        {
            Theme theme = (from d in _dbContext.Themes
                           where d.DictionaryId == query.DictionaryId && d.Id == query.ThemeId
                           select d).SingleOrDefault();

            if (theme == null)
            {
                _result = (IResult<List<Word>>)new InvalidResult().WithError("No theme of this id has been found.");
                return;
            }

            List<Word> words = (from d in _dbContext.Words
                                where d.ThemeId == theme.Id
                                select d).ToList();

            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;
            words.Skip(skipNum).Take(query.Amount);

            _result = new SuccessResult<List<Word>>(words);
        }
    }
}