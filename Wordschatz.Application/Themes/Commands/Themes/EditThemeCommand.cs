using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Themes.Commands
{
    public class EditThemeCommand : ICommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }

        public EditThemeCommand()
        {

        }

        public EditThemeCommand(long id, string name, long parentId)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ParentId = parentId;
        }
    }
}
