using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Domain.Models.Dictionaries
{
    public interface IDictionary
    {
        public void AddTag(string tag);
        public void AddTheme(Theme theme);
    }
}
