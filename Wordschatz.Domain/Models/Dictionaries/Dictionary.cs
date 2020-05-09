using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Dictionary : EventSourcedAggregate, IDictionary
    {
        public Name Name { get; protected set; }
        public Description Description { get; protected set; }
        public Visibility Visibility { get; protected set; }
        public EditPermission EditPermission { get; protected set; }
        public Password Password { get; protected set; }
        public virtual List<DictionaryMarks> Marks { get; protected set; }
        public virtual List<Theme> Themes { get; protected set; }

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
            Id = builder.id;
            Name = builder.name;
            Description = builder.description;
            Visibility = builder.visibility;
            EditPermission = builder.editPermission;
            Password = builder.password;
            Themes = builder.themes;
            Marks = new List<DictionaryMarks>();

            foreach (Mark m in builder.marks)
            {
                Marks.Add(new DictionaryMarks(m, this));
            }
        }
        public void ChangeName(string name)
        {
            try
            {
                Name newName = new Name(name);
                Name = newName;
            }
            catch
            {
                return;
            }
        }

        public void AddMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("The tag cannot be null.");

            Marks.Add( new DictionaryMarks(mark, this) );
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

        public void RemoveMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException(nameof(mark));

            var markToRemove = Marks.Find(m => m.DictionaryId == m.Dictionary.Id && m.Mark.Id == mark.Id);

            if (markToRemove == null)
                return;

            Marks.Remove(markToRemove);
        }

    }
}