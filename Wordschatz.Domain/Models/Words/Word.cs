using System;
using System.Collections.Generic;
using Wordschatz.Common.Entities;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.Domain.Models.Words
{
    public class Word : EventSourcedAggregate, IWord
    {
        public string Term { get; protected set; }
        public string Meaning { get; protected set; }

        public long ThemeId { get; protected set; }
        public virtual Theme Theme { get; protected set; }
        public virtual List<WordMarks> Marks { get; protected set; }

        public Word()
        {
        }

        public void ChangeTerm(string term)
        {
            Term = string.IsNullOrWhiteSpace(term) ?
                term :
                throw new ArgumentNullException("The term must be in human readable format.");
        }

        public void ChangeDefinition(string definition)
        {
            Meaning = string.IsNullOrWhiteSpace(definition) ?
                definition :
                throw new ArgumentNullException("The definition must be in human readable format.");
        }

        public void ChangeTheme(Theme newTheme)
        {
            Theme = newTheme ?? throw new ArgumentNullException("The new theme cannot be null.");
            ThemeId = newTheme.Id;
        }

        public void AddMark(Mark mark)
        {
            if (mark == null)
                throw new ArgumentNullException("The mark cannot be null.");

            Marks.Add(new WordMarks(mark, this));
        }
    }
}