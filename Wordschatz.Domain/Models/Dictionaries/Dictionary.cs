using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Dictionary : EventSourcedAggregate, IDictionary
    {
        public Name Name { get; protected set; }
        public Description Description { get; protected set; }
        public Visibility Visibility { get; protected set; }
        public EditPermission EditPermission { get; protected set; }
        public virtual List<Tag> Tags { get; protected set; }
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
            Tags = builder.tags;
            Themes = builder.themes;
        }

        public void AddTag(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("The tag cannot be null.");

            Tags.Add(tag);
        }

        public void AddTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException("The theme cannot be null.");

            Themes.Add(theme);
        }
    }
}
