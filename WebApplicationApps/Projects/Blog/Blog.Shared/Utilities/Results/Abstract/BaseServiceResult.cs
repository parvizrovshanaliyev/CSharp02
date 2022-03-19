using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;

namespace Blog.Shared.Utilities.Results.Abstract
{
    public abstract class BaseServiceResult
    {
        protected IResult<TResult> Ok<TResult>(TResult outPut)
        {
            return new Result<TResult>(ServiceResultCode.Ok, outPut);
        }

        protected IResult<TResult> Created<TResult>(TResult outPut)
        {
            return new Result<TResult>(ServiceResultCode.Created, BaseLocalization.CreatedSuccessfully, outPut);
        }

        protected IResult<TResult> Updated<TResult>(TResult output, string message)
        {
            return new Result<TResult>(ServiceResultCode.Updated, message, output);
        }

        protected IResult<TResult> Updated<TResult>(TResult outPut)
        {
            return new Result<TResult>(ServiceResultCode.Updated, BaseLocalization.ModifiedSuccessfully, outPut);
        }

        protected IResult<TResult> NotFound<TResult>(params string[] errors)
        {
            return new Result<TResult>(ServiceResultCode.NotFound, default, errors);
        }

        protected IResult<TResult> Deleted<TResult>(TResult output)
        {
            return new Result<TResult>(ServiceResultCode.Deleted, BaseLocalization.DeletedSuccessfully, output);
        }

        protected IResult<TResult> Error<TResult>(params string[] errors)
        {
            return new Result<TResult>(ServiceResultCode.Error, default, errors);
        }

        public IResult<TResult> Unauthorized<TResult>()
        {
            return new Result<TResult>(ServiceResultCode.Unauthorized, BaseLocalization.Unauthorized);
        }
    }
}