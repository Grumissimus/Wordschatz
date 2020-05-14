using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Application.Queries.Dictionaries;
using Wordschatz.Infrastructure.Context;
using System.Linq;
using Wordschatz.Application.Interfaces;

namespace Wordschatz.Application.QueryHandlers
{
    public class DictionaryQueryHandler : IQueryHandler<DictionaryGetByIdQuery, Dictionary>,
        IQueryHandler<DictionaryGetManyQuery, List<Dictionary>>,
        IQueryHandlerService
    {
        private readonly WordschatzContext _dbContext;

        public DictionaryQueryHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dictionary Execute(DictionaryGetByIdQuery query)
        {
            if(query == null)
                throw new ArgumentNullException(nameof(query));

            Dictionary dict = _dbContext.Dictionaries.Find( query.Id );

            return dict;
        }

        public List<Dictionary> Execute(DictionaryGetManyQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            List<Dictionary> dict = (from d in _dbContext.Dictionaries select d).ToList();
            int skipNum = (query.PageNum > 1 ? query.PageNum - 1 : 0) * query.Amount;
            dict.Where(d => d.Visibility == Visibility.Public).Skip(skipNum).Take(query.Amount);

            return dict;
        }
    }
}
