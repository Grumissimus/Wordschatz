using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Marks.Commands
{
    public class DeleteMarkCommand : ICommand
    {
        public long DictionaryId { get; set; }
        public long Id { get; set; }

        public DeleteMarkCommand(long dictid, long markId)
        {
            DictionaryId = dictid;
            Id = markId;
        }
    }
}
