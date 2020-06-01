using System;
using System.Collections.Generic;
using System.Text;

namespace Wordschatz.Common.Result
{
    public interface IResult<T>
    {
        bool Success { get; set; }
        List<string> Errors { get; set; }
        T Unwrap();
    }
}
