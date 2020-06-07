using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Marks.Queries.Handlers
{
    public class GetManyMarksQueryHandler : QueryHandler<GetManyMarksQuery, List<Mark>>
    {
        public GetManyMarksQueryHandler(WordschatzContext dbContext, IValidator<GetManyMarksQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(GetManyMarksQuery query)
        {
            List<Mark> marks = (from d in _dbContext.Marks where d.DictionaryId == query.DictionaryId select d).ToList();
            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;

            marks.Skip(skipNum).Take(query.Amount);

            _result = new SuccessResult<List<Mark>>(marks);
        }
    }
}