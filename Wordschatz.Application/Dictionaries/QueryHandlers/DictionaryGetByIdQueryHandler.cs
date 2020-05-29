using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Dictionaries.Queries;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Dictionaries.QueryHandlers
{
    public class DictionaryGetByIdQueryHandler : IQueryHandler<DictionaryGetByIdQuery, Dictionary>
    {
        private readonly WordschatzContext _dbContext;
        public DictionaryGetByIdQueryHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Dictionary Execute(DictionaryGetByIdQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            Dictionary dict = _dbContext.Dictionaries.Find(query.Id);

            return dict;
        }
    }
}
