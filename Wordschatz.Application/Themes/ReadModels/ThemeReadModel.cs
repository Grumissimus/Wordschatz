﻿using System.Collections.Generic;

namespace Wordschatz.Application.Themes.ReadModels
{
    public class ThemeReadModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int WordCount { get; set; }
        public long? ParentId { get; set; }
        public List<string> Marks { get; set; }
    }
}