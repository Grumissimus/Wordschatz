using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public class DictionaryBuilder : IDictionaryBuilder
    {
        public DictionaryName name;
        public DictionaryDescription description;
        public Visibility visibility;
        public EditPermission editPermission;
        public List<string> tags;
        public List<Theme> themes;

        public  DictionaryBuilder()
        {
            name = null;
            description = DictionaryDescription.For("");
            visibility = Visibility.Public;
            editPermission = EditPermission.OnlyCreator;
            tags = new List<string>();
            themes = new List<Theme>();
        }

        public IDictionaryBuilder AddTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentException(nameof(tag), "The tag cannot be null or empty.");

            tags.Add(tag);
            return this;
        }

        public IDictionaryBuilder AddTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme), "The theme cannot be null.");

            themes.Add(theme);
            return this;
        }
        public IDictionaryBuilder SetDescription(string description)
        {
            this.description = DictionaryDescription.For(description);
            return this;
        }

        public IDictionaryBuilder SetEditPermissionLevel(EditPermission permissionLevel)
        {
            this.editPermission = permissionLevel;
            return this;
        }

        public IDictionaryBuilder SetName(string name)
        {
            this.name = DictionaryName.For(name);
            return this;
        }

        public IDictionaryBuilder SetVisibility(Visibility visibility)
        {
            this.visibility = visibility;
            return this;
        }
        
        private void Validate()
        {
            if(name == null)
            {
                throw new ArgumentNullException("The dictionary must have the name.");
            }
        }

        public Dictionary Build()
        {
            Validate();
            return new Dictionary(this);
        }

    }
}
