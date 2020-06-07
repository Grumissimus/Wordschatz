using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.ValueObjects;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Dictionary : Entity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public Visibility Visibility { get; private set; }
        public EditPermission EditPermission { get; private set; }
        public Password Password { get; private set; }
        public virtual List<DictionaryMarks> Marks { get; private set; }
        public virtual List<Theme> Themes { get; private set; }

        /// <summary>
        /// EF Core constructor
        /// </summary>
        private Dictionary()
        {
            Themes = new List<Theme>();
            Marks = new List<DictionaryMarks>();
        }

        public Dictionary(DictionaryBuilder builder)
        {
            Id = builder.Id;
            Name = builder.Name;
            Description = builder.Description;
            Visibility = builder.Visibility;
            EditPermission = builder.EditPermission;
            Password = builder.Password;
            Themes = builder.Themes;
            Marks = new List<DictionaryMarks>();

            foreach (Mark m in builder.Marks)
            {
                Marks.Add(new DictionaryMarks(m, this));
            }
        }

        public void ChangeName(string name)
        {
            Name = new Name(name);
        }

        public void AddMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("The tag cannot be null.");

            Marks.Add(new DictionaryMarks(mark, this));
        }
        public void RemoveMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException(nameof(mark));

            var markToRemove = Marks.Find(m => m.DictionaryId == m.Dictionary.Id && m.Mark.Id == mark.Id);

            if (markToRemove == null)
                return;

            Marks.Remove(markToRemove);
        }

        public void AddTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException("The theme cannot be null.");

            Themes.Add(theme);
        }

        public void RemoveTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme));

            Themes.Remove(theme);
        }

    }
}