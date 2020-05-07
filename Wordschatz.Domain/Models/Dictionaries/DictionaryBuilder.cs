using System;
using System.Collections.Generic;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class DictionaryBuilder : IDictionaryBuilder
    {
        public ulong id;
        public Name name;
        public Description description;
        public Password password;
        public Visibility visibility;
        public EditPermission editPermission;
        public List<Theme> themes;

        public DictionaryBuilder()
        {
            id = 0;
            name = null;
            description = new Description("");
            password = null;
            visibility = Visibility.Public;
            editPermission = EditPermission.OnlyCreator;
            themes = new List<Theme>();
        }

        public IDictionaryBuilder SetId(ulong id)
        {
            this.id = id;
            return this;
        }

        public IDictionaryBuilder AddTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException("The theme cannot be null.");

            themes.Add(theme);
            return this;
        }

        public IDictionaryBuilder SetDescription(string description)
        {
            this.description = new Description(description);
            return this;
        }

        public IDictionaryBuilder SetEditPermissionLevel(EditPermission permissionLevel)
        {
            this.editPermission = permissionLevel;
            return this;
        }

        public IDictionaryBuilder SetName(string name)
        {
            this.name = new Name(name);
            return this;
        }

        public IDictionaryBuilder SetVisibility(Visibility visibility)
        {
            this.visibility = visibility;
            return this;
        }

        public IDictionaryBuilder SetPassword(string password)
        {
            this.password = new Password(password);
            return this;
        }

        private void Validate()
        {
            if (name == null)
                throw new ArgumentNullException("The dictionary must have the name.");
        }

        public Dictionary Build()
        {
            Validate();
            return new Dictionary(this);
        }
    }
}