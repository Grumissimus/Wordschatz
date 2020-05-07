using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Commands
{
    public class AddTagToDictionaryCommand : ICommand
    {
        public uint DictionaryId { get; set; }
        public string Tag { get; set; }

        public AddTagToDictionaryCommand(uint dictionaryId, string tag)
        {
            DictionaryId = dictionaryId;
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
        }
    }
}
