using FluentValidation;
using System;
using System.Collections.Generic;
using Wordschatz.Application.Dictionaries.Commands.Validators;
using Wordschatz.Application.Themes.Commands;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Commands.Handlers
{
    public class CreateThemeCommandHandler : ICommandHandler<CreateThemeCommand>
    {
        private readonly WordschatzContext _dbContext;

        public CreateThemeCommandHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(CreateThemeCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            Dictionary dict = _dbContext.Dictionaries.Find(command.DictionaryId);
            Theme parent = _dbContext.Themes.Find(command.ParentId);

            if (dict == null)
                throw new ArgumentNullException(nameof(dict));

            Theme newTheme = new ThemeBuilder()
                .SetName(command.Name)
                .SetDictionary(dict)
                .SetParent(parent)
                .Build();

            _dbContext.Themes.Add(newTheme);
            _dbContext.SaveChanges();

            command.Id = newTheme.Id;
        }
    }
}