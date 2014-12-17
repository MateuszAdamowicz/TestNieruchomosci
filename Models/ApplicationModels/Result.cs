using System;

namespace Models.ApplicationModels
{
    public class Result
    {
        public Result(bool success, Exception exception, string description)
        {
            Success = success;
            Exception = exception;
            Description = description;
        }

        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string Description { get; set; }
    }

    public class Result<T>
    {
        public Result(bool success, Exception exception, string description, T data)
        {
            Success = success;
            Exception = exception;
            Description = description;
            Data = data;
        }

        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }

    }
}