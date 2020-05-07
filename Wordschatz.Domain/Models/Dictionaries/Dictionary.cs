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

        public Dictionary()
        {
        }

        public Dictionary(DictionaryBuilder builder)
        {
            Id = builder.id;
            Name = builder.name;
            Description = builder.description;
            Visibility = builder.visibility;
            EditPermission = builder.editPermission;
            Password = builder.password;
            Marks = builder.marks;
            Themes = builder.themes;
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
    }
}