using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Marks.Commands
{
    public class CreateMarkCommand : ICommand
    {
        public long DictionaryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Output
        public long Id { get; set; }

        public CreateMarkCommand(long dictid, string name, string description)
        {
            DictionaryId = dictid;
            Name = name;
            Description = description;
        }
    }
}
