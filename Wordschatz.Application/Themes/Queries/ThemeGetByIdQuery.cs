using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Application.Themes.Queries
{
    public class ThemeGetByIdQuery : IQuery<Theme>
    {
        public long Id { get; set; }
        public long DictionaryId { get; set; }

        public ThemeGetByIdQuery(long id, long did)
        {
            Id = id;
            DictionaryId = did;
        }
    }
}