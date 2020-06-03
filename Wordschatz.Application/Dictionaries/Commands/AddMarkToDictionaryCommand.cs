using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Dictionaries.Commands
{
    public class AddMarkToDictionaryCommand : ICommand
    {
        public long MarkId { get; set; }
        public long DictionaryId { get; set; }

        public AddMarkToDictionaryCommand(long markId, long dictionaryId)
        {
            MarkId = markId;
            DictionaryId = dictionaryId;
        }
    }
}
