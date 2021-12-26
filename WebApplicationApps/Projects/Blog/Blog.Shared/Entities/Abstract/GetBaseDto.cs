using Blog.Shared.Utilities.Results.ComplexTypes;

namespace Blog.Shared.Entities.Abstract
{
    public abstract class GetBaseDto
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}