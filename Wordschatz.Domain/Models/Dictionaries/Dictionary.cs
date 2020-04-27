using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Dictionary : EventSourcedAggregate, IDictionary
    {
        public Name Name { get; set; }
        public Description Description { get; set; }
        public Visibility Visibility { get; set; }
        public EditPermission EditPermission { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Theme> Themes { get; set; }

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
                throw new ArgumentNullException("The tag cannot be null or empty.");

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
