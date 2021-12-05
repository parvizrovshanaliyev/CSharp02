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
        Task<IResult> AddAsync(CategoryAddDto dto, string createdByName);
        Task<IResult> UpdateAsync(CategoryUpdateDto dto, string createdByName);
        Task<IResult> DeleteAsync(int id, string modifiedByName);
        Task<IResult> HardDeleteAsync(int id);
    }
}