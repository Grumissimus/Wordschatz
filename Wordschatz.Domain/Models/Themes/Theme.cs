﻿using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.ValueObjects;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Themes
{
    public class Theme : Entity
    {
        public Name Name { get; private set; }
        public long DictionaryId { get; private set; }
        public virtual Dictionary Dictionary { get; private set; }
        public long? ParentId { get; private set; }
        public virtual Theme Parent { get; private set; }

        public virtual List<Word> Words { get; private set; }
        public virtual List<ThemeMarks> Marks { get; private set; }

        public Theme()
        {
            Words = new List<Word>();
            Marks = new List<ThemeMarks>();
        }

        public Theme(ThemeBuilder builder)
        {
            Name = builder.name;
            Dictionary = builder.dictionary;
            DictionaryId = builder.dictionary.Id;
            Dictionary.AddTheme(this);
            Parent = builder.parent;
            ParentId = builder.parent != null ? (long?)builder.parent.Id : null;

            Words = builder.words;
            foreach (Word word in Words)
            {
                word.ChangeTheme(this);
            }

            Marks = new List<ThemeMarks>();
            builder.marks.ForEach(
                x => Marks.Add(new ThemeMarks(x, this))
            );
        }

        public void AddWord(Word word)
        {
            if (word == null)
                throw new ArgumentNullException("The word cannot be null.");

            Words.Add(word);
        }

        public void AddMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("The mark cannot be null.");

            Marks.Add(new ThemeMarks(mark, this));
        }

        public void ChangeName(string newName)
        {
            try
            {
                Name nName = new Name(newName);
                Name = nName;
            }
            catch
            {
                return;
            }
        }

        public void MoveToOtherDictionary(Dictionary newDictionary)
        {
            if (newDictionary == null)
                throw new ArgumentNullException(nameof(newDictionary));

            if (newDictionary.Id == Dictionary.Id || newDictionary.Themes.Contains(this))
                return;

            Dictionary.RemoveTheme(this);
        }

        public void ChangeParent(Theme newParent)
        {
            if(newParent == null)
            {
                Parent = null;
                return;
            }
            Parent = newParent;
            ParentId = newParent.Id;
        }
    }
}