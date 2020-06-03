namespace Wordschatz.Common.Results
{
    public class SuccessResult : IResult
    {
        public bool IsValid() => true;
    }

    public class SuccessResult<T> : SuccessResult, IResult<T>
    {
        public T Data { get; }

        public SuccessResult(T data)
        {
            Data = data;
        }
    }
}