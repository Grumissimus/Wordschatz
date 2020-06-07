using FluentValidation;
using System.Linq;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Marks.Queries.Handlers
{
    public class GetMarkByIdQueryHandler : QueryHandler<GetMarkByIdQuery, Mark>
    {
        public GetMarkByIdQueryHandler(WordschatzContext dbContext, IValidator<GetMarkByIdQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(GetMarkByIdQuery query)
        {
            Mark mark = (from t in _dbContext.Marks
                           where t.Id == query.Id && t.DictionaryId == query.DictionaryId
                           select t).SingleOrDefault();

            _result = new SuccessResult<Mark>(mark);
        }
    }
}