using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models
{
    public enum DictionaryAccess
    {
        Public,
        NonPublic,
        PasswordProtected,
        Private
    }
}
