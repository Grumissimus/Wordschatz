using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class Dictionary : EventSourcedAggregate, IDictionary
    {
        public DictionaryName Name { get; set; }
        public DictionaryDescription Description { get; set; }
        public Visibility Visibility { get; set; }
        public EditPermission EditPermission { get; set; }
        public virtual List<string> Tags { get; set; }
        public virtual List<Theme> Themes { get; set; }

        public Dictionary()
        {
        }

        public Dictionary(DictionaryBuilder builder)
        {
            Name = builder.name;
            Description = builder.description;
            Visibility = builder.visibility;
            EditPermission = builder.editPermission;
            Tags = builder.tags;
            Themes = builder.themes;
        }

        public void AddTag(string tag)
        {

        }

        public void AddTheme(Theme theme)
        {

        }
    }
}
