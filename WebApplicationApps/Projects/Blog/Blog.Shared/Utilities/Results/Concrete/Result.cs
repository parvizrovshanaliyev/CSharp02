using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;

namespace Blog.Shared.Utilities.Results.Concrete
{
    public class Result<T> : IResult<T>
    {
        #region ctors

        public Result(ServiceResultCode serviceResultCode, T data = default, params string[] errors)
        {
            Data = data;
            ServiceResultCode = serviceResultCode;
            Errors = new List<string>(errors);
        }

        public Result(ServiceResultCode serviceResultCode, string message, T data = default, params string[] errors)
        {
            Data = data;
            Message = message;
            ServiceResultCode = serviceResultCode;
            Errors = new List<string>(errors);
        }

        #endregion

        #region Implementation of IResult<out T>

        public T Data { get; }
        public ServiceResultCode ServiceResultCode { get; }
        public string Message { get; }
        public IList<string> Errors { get; }
        public bool IsSuccess => !Errors.Any();
        public Exception Exception { get; }

        #endregion
    }
}