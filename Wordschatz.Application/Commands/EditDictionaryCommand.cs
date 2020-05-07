using System;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Commands
{
    public class EditDictionaryCommand : ICommand
    {
        public uint DictionaryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility Visibility { get; set; }
        public EditPermission EditPermission { get; set; }
        public string Password { get; set; }

        public EditDictionaryCommand(string name, string description, Visibility visibility, EditPermission editPermission, string password)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Visibility = visibility;
            EditPermission = editPermission;
            if (string.IsNullOrEmpty(password) && visibility == Visibility.PasswordProtected)
            {
                throw new ArgumentNullException(nameof(password));
            }
            else
            {
                Password = password;
            }
        }

    }
}