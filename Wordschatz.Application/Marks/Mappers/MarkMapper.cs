using System;
using System.Collections.Generic;
using Wordschatz.Application.Dictionaries.ReadModels;
using Wordschatz.Application.Marks.ReadModel;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;

namespace Wordschatz.Application.Dictionaries.Mapper
{
    public static class MarkMapper
    {
        public static MarkReadModel MapToReadModel(Mark mark)
        {
            if (mark == null)
                return default;

            MarkReadModel markRead = new MarkReadModel
            {
                Id = mark.Id,
                Name = mark.Name,
                Description = mark.Description,
            };

            return markRead;
        }
    }
}