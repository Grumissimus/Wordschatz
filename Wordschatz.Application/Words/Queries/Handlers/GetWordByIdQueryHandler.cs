using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.Words;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Words.Queries.Handlers
{
    public class GetWordByIdQueryHandler : QueryHandler<GetWordByIdQuery, Word>
    {
        public GetWordByIdQueryHandler(WordschatzContext dbContext, IValidator<GetWordByIdQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(GetWordByIdQuery query)
        {
            Theme theme = (from d in _dbContext.Themes
                           where d.DictionaryId == query.DictionaryId && d.Id == query.ThemeId
                           select d).SingleOrDefault();

            if (theme == null)
            {
                _result = (IResult<Word>)new InvalidResult<Word>().WithError("No theme of this id has been found.");
                return;
            }

            Word word = (from d in _dbContext.Words
                         where d.ThemeId == theme.Id && d.Id == query.Id
                         select d).SingleOrDefault();

            _result = new SuccessResult<Word>(word);
        }
    }
}