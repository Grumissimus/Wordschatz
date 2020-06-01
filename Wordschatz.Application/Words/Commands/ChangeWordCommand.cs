using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Application.Words.Commands
{
    public class ChangeWordCommand
    {
        public long Id { get; set; }
        public string Term { get; protected set; }
        public string Meaning { get; protected set; }
        public ChangeWordCommand(long id, string term, string meaning)
        {
            Id = id;
            Term = term;
            Meaning = meaning;
        }
    }
}
