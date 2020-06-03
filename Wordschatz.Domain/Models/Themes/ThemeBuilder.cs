using System;
using System.Collections.Generic;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.ValueObjects;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Themes
{
    public class ThemeBuilder : IThemeBuilder
    {
        public long id;
        public Name name;
        public Dictionary dictionary;
        public Theme parent;
        public List<Word> words;
        public List<Mark> marks;

        public ThemeBuilder()
        {
            parent = null;
            words = new List<Word>();
            marks = new List<Mark>();
        }

        public IThemeBuilder AddMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("The mark cannot be null.");

            marks.Add(mark);
            return this;
        }

        public IThemeBuilder AddWord(Word word)
        {
            if (word == null)
                throw new ArgumentNullException("The word cannot be null.");

            words.Add(word);
            return this;
        }

        private void Validate()
        {
            if (name == null)
                throw new ArgumentException("The name cannot be null.");

            if (dictionary == null)
                throw new ArgumentException("The dictionary cannot be null.");
        }

        public Theme Build()
        {
            Validate();
            return new Theme(this);
        }

        public IThemeBuilder SetDictionary(Dictionary dictionary)
        {
            this.dictionary = dictionary ?? throw new ArgumentNullException("The dictionary cannot be null.");
            return this;
        }

        public IThemeBuilder SetId(long id)
        {
            this.id = id;
            return this;
        }

        public IThemeBuilder SetName(string name)
        {
            this.name = new Name(name);
            return this;
        }

        public IThemeBuilder SetParent(Theme parent)
        {
            if (parent == null)
            {
                this.parent = null;
                return this;
            }

            if (parent.Id == id)
            {
                throw new ArgumentException("The child theme cannot be its parent.");
            }

            this.parent = parent;
            return this;
        }
    }
}