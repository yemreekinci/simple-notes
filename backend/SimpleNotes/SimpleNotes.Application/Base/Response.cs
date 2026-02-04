namespace SimpleNotes.Application.Base
{
    public class Response<T>
    {
        public bool IsSuccess { get; }
        public bool IsFail => !IsSuccess;
        public T? Data { get; }
        public string? Error { get; }

        private Response(bool isSuccess, T? data, string? error)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }

        public static Response<T> Success(T data)
        {
            return new Response<T>(true, data, null);
        }

        public static Response<T> Fail(string error)
        {
            return new Response<T>(false, default, error);
        }
    }
}
