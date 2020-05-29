using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Common.Queries;

namespace Wordschatz.Application.Queries.Themes
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
