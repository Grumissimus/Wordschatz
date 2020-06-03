using FluentValidation;
using Wordschatz.Application.Common;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.Queries.Handlers
{
    public class DictionaryGetByIdQueryHandler : QueryHandler<DictionaryGetByIdQuery, Dictionary>
    {
        public DictionaryGetByIdQueryHandler(WordschatzContext dbContext, IValidator<DictionaryGetByIdQuery> validator) : base(dbContext, validator)
        {
        }

        public override void Handle(DictionaryGetByIdQuery query)
        {
            Dictionary dict = _dbContext.Dictionaries.Find(query.Id);
            _result = new SuccessResult<Dictionary>(dict);
        }
    }
}