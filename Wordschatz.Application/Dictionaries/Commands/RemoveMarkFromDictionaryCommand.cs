using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Dictionaries.Commands
{
    public class RemoveMarkFromDictionaryCommand : ICommand
    {
        public long MarkId { get; set; }
        public long DictionaryId { get; set; }

        public RemoveMarkFromDictionaryCommand(long markId, long dictionaryId)
        {
            MarkId = markId;
            DictionaryId = dictionaryId;
        }
    }
}
