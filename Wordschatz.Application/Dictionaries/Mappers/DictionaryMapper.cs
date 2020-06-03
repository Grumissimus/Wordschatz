using System;
using System.Collections.Generic;
using Wordschatz.Application.Dictionaries.ReadModels;
using Wordschatz.Domain.Models;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Mapper
{
    public static class DictionaryMapper
    {
        public static DictionaryReadModel MapToReadModel(Dictionary dictionary)
        {
            if (dictionary == null)
                throw new ArgumentException("Dictionary cannot be a null value");

            DictionaryReadModel dictRead = new DictionaryReadModel
            {
                Id = dictionary.Id,
                Name = dictionary.Name,
                Description = dictionary.Description,
                Marks = new List<string>()
            };

            foreach (DictionaryMarks dm in dictionary.Marks)
            {
                dictRead.Marks.Add(dm.Mark.Name.Value);
            }

            dictRead.ThemeCount = dictionary.Themes.Count;

            return dictRead;
        }
    }
}