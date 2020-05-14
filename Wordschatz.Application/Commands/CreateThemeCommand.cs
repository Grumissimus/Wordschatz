using System;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Commands
{
    public class CreateThemeCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong DictionaryId { get; set; }
        public ulong? ParentId { get; set; }
        
        public CreateThemeCommand(string name, string description, ulong dictionaryId, ulong? parentId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            DictionaryId = dictionaryId;
            ParentId = parentId;
        }
    }
}