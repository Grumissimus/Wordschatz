﻿using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public interface IDictionary
    {
        public void AddMark(Mark mark);
        public void AddTheme(Theme theme);
    }
}