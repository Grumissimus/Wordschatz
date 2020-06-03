﻿using System;
using System.Collections.Generic;
using Wordschatz.Application.Words.ReadModels;
using Wordschatz.Domain.Models;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Application.Words.Mappers
{
    public static class WordMapper
    {
        public static WordReadModel MapToReadModel(Word word)
        {
            if (word == null)
                throw new ArgumentException("Word cannot be a null value");

            WordReadModel wordReadModel = new WordReadModel
            {
                Id = word.Id,
                Term = word.Term,
                Meaning = word.Meaning,
                ThemeId = word.ThemeId,
                Marks = new List<string>()
            };

            foreach (WordMarks tm in word.Marks)
            {
                wordReadModel.Marks.Add(tm.Mark.Name.Value);
            }

            return wordReadModel;
        }
    }
}