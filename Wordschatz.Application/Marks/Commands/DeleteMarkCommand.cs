using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Commands;

namespace Wordschatz.Application.Marks.Commands
{
    public class DeleteMarkCommand : ICommand
    {
        public string MarkId { get; set; }

        public DeleteMarkCommand(string markId)
        {
            MarkId = markId;
        }
    }
}
