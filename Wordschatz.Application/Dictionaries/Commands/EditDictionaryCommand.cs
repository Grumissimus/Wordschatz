﻿using System;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.Application.Dictionaries.Commands
{
    public class EditDictionaryCommand : ICommand
    {
        public long DictionaryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility VisibilityLevel { get; set; }
        public EditPermission EditPermission { get; set; }
        public string Password { get; set; }

        public EditDictionaryCommand()
        {

        }

        public EditDictionaryCommand(string name, string description, Visibility visibility, EditPermission editPermission, string password)
        {
            Name = name ?? throw new ArgumentException(nameof(name));
            Description = description ?? throw new ArgumentException(nameof(description));
            VisibilityLevel = visibility;
            EditPermission = editPermission;
            if (string.IsNullOrEmpty(password) && visibility == Visibility.PasswordProtected)
            {
                throw new ArgumentException("Dictionary with password protection requires a password");
            }
            else
            {
                Password = password;
            }
        }
    }
}