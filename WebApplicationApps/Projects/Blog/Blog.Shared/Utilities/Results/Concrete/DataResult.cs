using System;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;

namespace Blog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, T data, string message)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, string message, Exception exception, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}