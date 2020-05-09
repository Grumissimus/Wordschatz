using System;
using System.Collections.Generic;
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
        public virtual List<ThemeMarks> Marks { get; protected set; }

        public Theme()
        {
        }

        public Theme(ThemeBuilder builder)
        {
            Name = builder.name;
            Dictionary = builder.dictionary;
            DictionaryId = builder.dictionary.Id;
            Dictionary.AddTheme(this);
            Parent = builder.parent;
            ParentId = builder.parent != null ? (ulong?)builder.parent.Id : null;

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
            try { 
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
            Parent = newParent ?? throw new ArgumentNullException(nameof(newParent));
            ParentId = newParent.Id;
        }
    }
}