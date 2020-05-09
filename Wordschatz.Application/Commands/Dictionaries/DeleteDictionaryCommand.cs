using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Commands.Dictionaries
{
    public class DeleteDictionaryCommand : ICommand
    {
        public uint Id { get; set; }

        public DeleteDictionaryCommand(uint id)
        {
            Id = id;
        }
    }
}
