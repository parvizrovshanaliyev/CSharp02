using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IResult<CategoryDto>> GetAsync(int id);
        Task<IResult<CategoryUpdateDto>> GetUpdateDtoAsync(int id);
        Task<IResult<IList<CategoryDto>>> GetAllAsync();
        Task<IResult<IList<CategoryDto>>> GetAllByNonDeletedAsync();
        Task<IResult<CategoryDto>> AddAsync(CategoryAddDto dto, string createdByName);
        Task<IResult<CategoryDto>> UpdateAsync(CategoryUpdateDto dto, string createdByName);
        Task<IResult<CategoryDto>> DeleteAsync(int id, string modifiedByName);
        Task<IResult<bool>> HardDeleteAsync(int id);
        Task<IResult<int>> CountAsync(bool isDeleted = false);
    }
}