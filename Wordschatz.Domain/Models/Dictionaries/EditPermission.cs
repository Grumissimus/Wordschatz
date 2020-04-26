using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public enum EditPermission
    {
        OnlyCreator,
        OnlyPassword,
        OnlyGroup,
        Anyone
    }
}
