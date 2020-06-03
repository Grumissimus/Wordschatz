using System;
using System.Collections.Generic;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Domain.Models.ValueObjects;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class DictionaryBuilder : IDictionaryBuilder
    {
        public long Id { get; private set; }
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public Password Password { get; private set; }
        public Visibility Visibility { get; private set; }
        public EditPermission EditPermission { get; private set; }
        public List<Theme> Themes { get; private set; }
        public List<Mark> Marks { get; private set; }

        public DictionaryBuilder()
        {
            Id = 0;
            Name = new Name("New Dictionary");
            Description = new Description("");
            Password = null;
            Visibility = Visibility.Public;
            EditPermission = EditPermission.OnlyCreator;
            Themes = new List<Theme>();
            Marks = new List<Mark>();
        }

        public IDictionaryBuilder SetId(long id)
        {
            this.Id = id;
            return this;
        }

        public IDictionaryBuilder AddMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentException("The mark cannot be null.");

            Marks.Add(mark);
            return this;
        }

        public IDictionaryBuilder AddTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentException("The theme cannot be null.");

            Themes.Add(theme);
            return this;
        }

        public IDictionaryBuilder SetDescription(string description)
        {
            Description = new Description(description);
            return this;
        }

        public IDictionaryBuilder SetEditPermissionLevel(EditPermission permissionLevel)
        {
            EditPermission = permissionLevel;
            return this;
        }

        public IDictionaryBuilder SetName(string name)
        {
            Name = new Name(name);
            return this;
        }

        public IDictionaryBuilder SetVisibility(Visibility visibility)
        {
            Visibility = visibility;
            return this;
        }

        public IDictionaryBuilder SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password) && Visibility != Visibility.PasswordProtected)
                return this;

            Password = new Password(password);
            return this;
        }

        public Dictionary Build()
        {
            return new Dictionary(this);
        }
    }
}