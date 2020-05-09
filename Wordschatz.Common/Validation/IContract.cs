using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Common.Validation
{
    /**
     * A contract is an object that validates an input based on
     * a set of finite rules.
     *
     */
    /// <summary>
    /// The contract interface.
    /// </summary>
    public interface IContract
    {
        public List<IRule> Rules { get; set; }
        public void Validate();
    }
}
