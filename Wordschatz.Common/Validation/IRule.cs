using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Common.Validation
{
    public interface IRule
    {
        public bool Apply(); 
    }
}
