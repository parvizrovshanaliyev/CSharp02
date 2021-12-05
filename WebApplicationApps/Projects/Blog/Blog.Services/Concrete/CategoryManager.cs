using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;

namespace Blog.Services.Concrete
{
    public class CategoryManager:ICategoryService
    {
        #region fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region ctor
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region methods

        public async Task<IDataResult<CategoryDto>> GetAsync(int id)
        {
            var entity=  await _unitOfWork.Categories.GetAsync(i=>i.Id==id, c=>c.Posts);

            if (entity != null)
            {
                var dto = new CategoryDto()
                {
                    Entity = entity,
                    ResultStatus = ResultStatus.Success
                };
                return new DataResult<CategoryDto>(resultStatus:ResultStatus.Success,dto);
            }
            return new DataResult<CategoryDto>(resultStatus:ResultStatus.Error,null,"not found");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync(null, c => c.Posts);
            
            if (entities.Count > -1)
            {
                var dto = new CategoryListDto()
                {
                    Entities = entities,
                    ResultStatus = ResultStatus.Success
                };
                return new DataResult<CategoryListDto>(ResultStatus.Success,dto );
            }

            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "not found");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Posts);
            if (entities.Count > -1)
            {
                var dto = new CategoryListDto()
                {
                    Entities = entities,
                    ResultStatus = ResultStatus.Success
                };
                return new DataResult<CategoryListDto>(ResultStatus.Success,dto );
            }

            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "not found");
        }
        
        public async Task<IResult> AddAsync(CategoryAddDto dto, string createdByName)
        {
            var entity = new Category(dto.Name, dto.Description, dto.Note);
            entity.SetIsActive(dto.IsActive);
            entity.SetCreatedByName(createdByName);
            await _unitOfWork.Categories.AddAsync(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} created");
            return new Result(ResultStatus.Error, $"{entity.Name} not created");
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto dto, string modifiedByName)
        {
            var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == dto.Id);
            if (entity == null) return new Result(ResultStatus.Error, $"{dto.Id} not found");
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Note = dto.Note;
            entity.SetIsActive(dto.IsActive);
            entity.SetModifiedByName(modifiedByName);
            entity.SetIsDeleted(dto.IsDeleted);
            await _unitOfWork.Categories.UpdateAsync(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} modified");
            return new Result(ResultStatus.Error, $"{entity.Name} not modified");
        }

        public async Task<IResult> DeleteAsync(int id, string modifiedByName)
        {
            var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == id);
            if (entity == null) return new Result(ResultStatus.Error, $"{id} not found");
            entity.SetIsDeleted(false);
            entity.SetModifiedByName(modifiedByName);
            await _unitOfWork.Categories.UpdateAsync(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} removed");
            return new Result(ResultStatus.Error, $"{entity.Name} not removed");
        }

        public async Task<IResult> HardDeleteAsync(int id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == id);
            if (entity == null) return new Result(ResultStatus.Error, $"{id} not found");
            await _unitOfWork.Categories.DeleteAsync(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} removed");
            return new Result(ResultStatus.Error, $"{entity.Name} not removed");
        }

        #endregion
    }
}