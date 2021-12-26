using System.Threading.Tasks;
using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetAsync(int id);
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto dto, string createdByName);
        Task<IDataResult<CategoryUpdateDto>> GetUpdateDtoAsync(int id);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto dto, string createdByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int id, string modifiedByName);
        Task<IResult> HardDeleteAsync(int id);
    }
}