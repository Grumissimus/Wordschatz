using System.Collections.Generic;

namespace Wordschatz.Common.Results
{
    public class InvalidResult : IResult
    {
        public List<string> Errors { get; protected set; }

        public bool IsValid() => false;

        public InvalidResult()
        {
            Errors = new List<string>();
        }

        public InvalidResult(List<string> errors)
        {
            Errors = errors;
        }

        public InvalidResult WithError(string message)
        {
            Errors.Add(message);
            return this;
        }
    }

    public class InvalidResult<T> : InvalidResult, IResult<T>
    {
        public InvalidResult()
        {
            Errors = new List<string>();
        }

        public InvalidResult(List<string> errors) : base(errors)
        {
        }
    }
}