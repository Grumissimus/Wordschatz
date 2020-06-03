using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Marks.Commands
{
    public class CreateMarkCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateMarkCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
