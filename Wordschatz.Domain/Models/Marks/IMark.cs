using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.Domain.Models.Marks
{
    public interface IMark
    {
        void ChangeName(string name);
        void ChangeDescription(string description);
        void AddWord(Word word);
    }
}
