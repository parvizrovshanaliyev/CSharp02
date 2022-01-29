using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;

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
    }
}