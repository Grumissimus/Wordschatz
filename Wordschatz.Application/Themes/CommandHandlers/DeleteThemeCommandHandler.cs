using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Application.Themes.Commands;
using Wordschatz.Common.Commands;
using Wordschatz.Domain.Models.Themes;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.Application.Themes.CommandHandlers
{
    public class DeleteThemeCommandHandler : ICommandHandler<DeleteThemeCommand>
    {
        private readonly WordschatzContext _dbContext;

        public DeleteThemeCommandHandler(WordschatzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(DeleteThemeCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            Theme theme = (from t in _dbContext.Themes
                           where t.Id == command.Id && t.DictionaryId == command.DictionaryId
                           select t).Single();

            if (theme == null)
                return;

            _dbContext.Themes.Remove(theme);
            _dbContext.SaveChanges();
        }
    }
}
