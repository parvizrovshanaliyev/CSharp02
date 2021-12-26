using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.Services.Concrete
{
    public class PostManager : ICategoryService
    {
        #region fields

        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region ctor

        public PostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Implementation of ICategoryService

        public Task<IDataResult<CategoryDto>> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> AddAsync(CategoryAddDto dto, string createdByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> UpdateAsync(CategoryUpdateDto dto, string createdByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> DeleteAsync(int id, string modifiedByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> HardDeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
