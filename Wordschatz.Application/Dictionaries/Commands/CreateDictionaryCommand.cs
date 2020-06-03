using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands
{
    public class CreateDictionaryCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility VisibilityLevel { get; set; }
        public EditPermission EditPermission { get; set; }
        public string Password { get; set; }

        // output property
        public long DictionaryId { get; internal set; }

        public CreateDictionaryCommand()
        {
        }

        public CreateDictionaryCommand(string name, string description, Visibility visibility, EditPermission editPermission, string password)
        {
            Name = name;
            Description = description;
            VisibilityLevel = visibility;
            EditPermission = editPermission;
            Password = password;
        }
    }
}