using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.ValueObjects;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Marks
{
    /// <summary>
    /// A mark class.
    /// </summary>
    public class Mark : Entity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public long DictionaryId {get; private set; }
        public virtual Dictionary Dictionary { get; private set; }

        public virtual List<WordMarks> Words { get; private set; }
        public virtual List<ThemeMarks> Themes { get; private set; }

        public Mark()
        {
            Words = new List<WordMarks>();
            Themes = new List<ThemeMarks>();
        }

        public Mark(string name, string description, Dictionary dictionary)
        {
            Name = new Name(name);
            Description = new Description(description);
            Words = new List<WordMarks>();
            Themes = new List<ThemeMarks>();
            Dictionary = dictionary;
            DictionaryId = dictionary.Id;
        }

        public Mark(long id, string name, string description, Dictionary dictionary)
        {
            Id = id;
            Name = new Name(name);
            Description = new Description(description);
            Words = new List<WordMarks>();
            Themes = new List<ThemeMarks>();
            Dictionary = dictionary;
            DictionaryId = dictionary.Id;
        }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        public void ChangeDescription(string description)
        {
            Description = new Description(description);
        }
    }
}