using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Wordschatz.Application.Themes.Commands;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.Commands.Handlers
{
    public class EditThemeCommandHandler : ICommandHandler<EditThemeCommand>
    {
        private readonly WordschatzContext _dbContext;

        public EditThemeCommandHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(EditThemeCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (command.Id <= 0)
                throw new ArgumentException("Id must be a positive number bigger than zero.");

            Theme themeToChange = _dbContext.Themes.Find(command.Id);
            Theme parent = _dbContext.Themes.Find(command.ParentId);

            themeToChange.ChangeName(command.Name);
            themeToChange.ChangeParent(parent);

            _dbContext.Themes.Update(themeToChange);
            _dbContext.SaveChanges();
        }
    }
}
