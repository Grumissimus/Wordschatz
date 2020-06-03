using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Application.Words.Queries
{
    public class GetWordByIdQuery : IQuery<Word>
    {
        public long DictionaryId { get; set; }
        public long ThemeId { get; set; }
        public long Id { get; set; }

        public GetWordByIdQuery(long dictionaryId, long themeId, long id)
        {
            DictionaryId = dictionaryId;
            ThemeId = themeId;
            Id = id;
        }
    }
}