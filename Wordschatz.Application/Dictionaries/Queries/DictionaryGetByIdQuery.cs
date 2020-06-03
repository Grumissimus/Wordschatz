using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Queries
{
    public class DictionaryGetByIdQuery : IQuery<Dictionary>
    {
        public long Id { get; set; }

        public DictionaryGetByIdQuery(long id)
        {
            Id = id;
        }
    }
}