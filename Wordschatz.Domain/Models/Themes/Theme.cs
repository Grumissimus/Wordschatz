﻿using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Themes
{
    public class Theme : EventSourcedAggregate, ITheme
    {
        public Name Name { get; protected set; }
        public ulong DictionaryId { get; protected set; }
        public virtual Dictionary Dictionary { get; protected set; }
        public ulong? ParentId { get; protected set; }
        public virtual Theme Parent { get; protected set; }

        public virtual List<Word> Words { get; protected set; }
        public virtual List<MarkTheme> Marks { get; protected set; }

        public Theme()
        {
        }

        public Theme(ThemeBuilder builder)
        {
            Name = builder.name;
            Dictionary = builder.dictionary;
            DictionaryId = builder.dictionary.Id;
            Parent = builder.parent;
            ParentId = builder.parent != null ? builder.parent.Id : 0;

            Words = builder.words;
            foreach(Word word in Words)
            {
                word.ChangeTheme(this);
            }

            Marks = new List<MarkTheme>();
            builder.marks.ForEach(
                x => Marks.Add( new MarkTheme(x, this) )
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
            if(mark == null)
                throw new ArgumentNullException("The mark cannot be null.");

            Marks.Add( new MarkTheme(mark, this) );
        }
    }
}