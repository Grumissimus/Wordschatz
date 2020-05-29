using System;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands
{
    public class CreateDictionaryCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility Visibility { get; set; }
        public EditPermission EditPermission { get; set; }
        public string Password { get; set; }

        // output property
        public long DictionaryId { get; internal set; }

        public CreateDictionaryCommand()
        {

        }

        public CreateDictionaryCommand(string name, string description, Visibility visibility, EditPermission editPermission, string password)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Visibility = visibility | Visibility.Public;
            EditPermission = editPermission | EditPermission.OnlyCreator;
            if (string.IsNullOrEmpty(password) && visibility == Visibility.PasswordProtected)
            {
                throw new ArgumentException("Dictionaries protected by password requires a password (obviously).");
            }
            else
            {
                Password = password;
            }
        }
    }
}