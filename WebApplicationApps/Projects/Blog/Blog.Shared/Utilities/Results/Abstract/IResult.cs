using System;
using System.Collections.Generic;
using Blog.Shared.Utilities.Results.ComplexTypes;

namespace Blog.Shared.Utilities.Results.Abstract
{
    public interface IResult<out T> 
    {
        public T Data { get; }
        public ServiceResultCode ServiceResultCode { get; }
        public string Message { get; }
        public IList<string> Errors { get; }
        public bool IsSuccess { get; }
        public Exception Exception { get; }
    }
}