using System;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Themes.Commands
{
    public class CreateThemeCommand : ICommand
    {
        public string Name { get; set; }
        public long DictionaryId { get; set; }
        public long? ParentId { get; set; }

        //Output property
        public long Id { get; set; }

        public CreateThemeCommand()
        {
        }

        public CreateThemeCommand(string name, long dictionaryId, long? parentId)
        {
            Name = name;
            DictionaryId = dictionaryId;
            ParentId = parentId;
        }
    }
}