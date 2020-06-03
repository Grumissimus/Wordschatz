using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Marks.Commands
{
    public class ChangeMarkCommand : ICommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ChangeMarkCommand(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
