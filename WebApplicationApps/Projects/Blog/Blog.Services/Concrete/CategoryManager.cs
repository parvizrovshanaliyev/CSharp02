using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Constants;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;

namespace Blog.Services.Concrete
{
    public class CategoryManager:ICategoryService
    {
        #region fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CategoryManager(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region methods

        public async Task<IDataResult<CategoryDto>> GetAsync(int id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(i => i.Id == id);

            if (entity == null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, GlobalConstants.NoDataAvailableOnRequest, new CategoryDto()
                {
                    Message = GlobalConstants.NoDataAvailableOnRequest,
                    ResultStatus = ResultStatus.Error
                });
            }

            var dto = new CategoryDto()
            {
                Entity = entity,
                ResultStatus = ResultStatus.Success
            };

            return new DataResult<CategoryDto>(resultStatus: ResultStatus.Success, data: dto);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync();

            if (entities.Count <= -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, GlobalConstants.NoDataAvailableOnRequest, new CategoryListDto()
                {
                    Message = GlobalConstants.NoDataAvailableOnRequest,
                    ResultStatus = ResultStatus.Error
                });
            }
            var dto = new CategoryListDto()
            {
                Entities = entities,
                ResultStatus = ResultStatus.Success
            };
            return new DataResult<CategoryListDto>(ResultStatus.Success, dto);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted);
            
            if (entities.Count <= -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, GlobalConstants.NoDataAvailableOnRequest, new CategoryListDto()
                {
                    Message = GlobalConstants.NoDataAvailableOnRequest,
                    ResultStatus = ResultStatus.Error
                });
                
            }
            var dto = new CategoryListDto()
            {
                Entities = entities,
                ResultStatus = ResultStatus.Success
            };
            return new DataResult<CategoryListDto>(ResultStatus.Success, dto);
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto dto, string createdByName)
        {
            var entity = _mapper.Map<Category>(dto);
            entity.SetCreatedByName(createdByName);
            
            var addedEntity = await _unitOfWork.Categories.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var resultDto = new CategoryDto()
            {
                Entity = addedEntity,
                ResultStatus = ResultStatus.Success,
                Message = GlobalConstants.CreatedSuccessfully
            };
            return new DataResult<CategoryDto>(ResultStatus.Success, GlobalConstants.CreatedSuccessfully, resultDto);
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetUpdateDtoAsync(int id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(i => i.Id == id);

            if (entity == null)
            {
                return new DataResult<CategoryUpdateDto>(resultStatus: ResultStatus.Error, GlobalConstants.NoDataAvailableOnRequest);
            }

            var dto = _mapper.Map<CategoryUpdateDto>(entity);

            return new DataResult<CategoryUpdateDto>(resultStatus: ResultStatus.Success, dto);
        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto dto, string createdByName)
        {
            var dbEntity = await _unitOfWork.Categories.GetAsync(i => i.Id == dto.Id);
            var entity = _mapper.Map<CategoryUpdateDto, Category>(dto, dbEntity);
            var updatedEntity = await _unitOfWork.Categories.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var resultDto = new CategoryDto()
            {
                Entity = updatedEntity,
                ResultStatus = ResultStatus.Success,
                Message = GlobalConstants.ModifiedSuccessfully
            };
            return new DataResult<CategoryDto>(ResultStatus.Success, resultDto);
        }

        public async Task<IDataResult<CategoryDto>> DeleteAsync(int id, string modifiedByName)
        {
            var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == id);

            if (entity == null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, GlobalConstants.NoDataAvailableOnRequest);
            }
            entity.SetIsDeleted(true);
            entity.SetModifiedByName(modifiedByName);
            var deletedEntity = await _unitOfWork.Categories.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var resultDto = new CategoryDto()
            {
                Entity = deletedEntity,
                ResultStatus = ResultStatus.Success
            };
            return new DataResult<CategoryDto>(ResultStatus.Success, GlobalConstants.DeletedSuccessfully, resultDto);
        }

        //public async Task<IResult> AddAsync(CategoryAddDto dto, string createdByName)
        //{
        //    var entity = new Category(dto.Name, dto.Description, dto.Note);
        //    entity.SetIsActive(dto.IsActive);
        //    entity.SetCreatedByName(createdByName);
        //    await _unitOfWork.Categories.AddAsync(entity);
        //    var result = await _unitOfWork.SaveChangesAsync();
        //    if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} created");
        //    return new Result(ResultStatus.Error, $"{entity.Name} not created");
        //}

        //public async Task<IResult> UpdateAsync(CategoryUpdateDto dto, string modifiedByName)
        //{
        //    var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == dto.Id);
        //    if (entity == null) return new Result(ResultStatus.Error, $"{dto.Id} not found");
        //    entity.Name = dto.Name;
        //    entity.Description = dto.Description;
        //    entity.Note = dto.Note;
        //    entity.SetIsActive(dto.IsActive);
        //    entity.SetModifiedByName(modifiedByName);
        //    entity.SetIsDeleted(dto.IsDeleted);
        //    await _unitOfWork.Categories.UpdateAsync(entity);
        //    var result = await _unitOfWork.SaveChangesAsync();
        //    if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} modified");
        //    return new Result(ResultStatus.Error, $"{entity.Name} not modified");
        //}

        //public async Task<IResult> DeleteAsync(int id, string modifiedByName)
        //{
        //    var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == id);
        //    if (entity == null) return new Result(ResultStatus.Error, $"{id} not found");
        //    entity.SetIsDeleted(false);
        //    entity.SetModifiedByName(modifiedByName);
        //    await _unitOfWork.Categories.UpdateAsync(entity);
        //    var result = await _unitOfWork.SaveChangesAsync();
        //    if (result > 0) return new Result(ResultStatus.Success, $"{entity.Name} removed");
        //    return new Result(ResultStatus.Error, $"{entity.Name} not removed");
        //}

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