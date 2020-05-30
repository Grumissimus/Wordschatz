using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Themes.ReadModels;
using Wordschatz.Domain.Models;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Application.Themes.Mappers
{
    public static class ThemeMapper
    {
        public static ThemeReadModel MapToReadModel(Theme theme)
        {
            if (theme == null)
                throw new ArgumentException("Dictionary cannot be a null value");

            ThemeReadModel themeRead = new ThemeReadModel
            {
                Id = theme.Id,
                Name = theme.Name,
                WordCount = theme.Words.Count,
                ParentId = theme.ParentId,
                Marks = new List<string>()
            };

            foreach(ThemeMarks tm in theme.Marks)
            {
                themeRead.Marks.Add(tm.Mark.Name.Value);
            }

            return themeRead;
        }
    }
}
