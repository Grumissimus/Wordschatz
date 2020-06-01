using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Themes.Commands
{
    public class EditThemeCommand : ICommand
    {
        public long Id { get; set; }
        public long DictionaryId { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public EditThemeCommand()
        {
        }

        public EditThemeCommand(long id, long did, string name, long? parentId)
        {
            Id = id;
            DictionaryId = did;
            Name = name;
            ParentId = parentId;
        }
    }
}
