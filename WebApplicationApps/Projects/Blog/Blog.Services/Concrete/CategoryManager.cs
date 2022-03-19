using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class CategoryManager : BaseServiceResult, ICategoryService
    {
        #region ctor

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region methods

        public async Task<IResult<CategoryDto>> GetAsync(int id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<CategoryDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<CategoryDto>(entity);
            return Ok(outputDto);
        }

        public async Task<IResult<CategoryUpdateDto>> GetUpdateDtoAsync(int id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<CategoryUpdateDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<CategoryUpdateDto>(entity);
            return Ok(outputDto);
        }

        public async Task<IResult<IList<CategoryDto>>> GetAllAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync();
            if (entities is null)
                return NotFound<IList<CategoryDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<CategoryDto>>(entities);
            return Ok(outputDto);
        }

        public async Task<IResult<IList<CategoryDto>>> GetAllByNonDeletedAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync(i => !i.IsDeleted);
            if (entities is null)
                return NotFound<IList<CategoryDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<CategoryDto>>(entities);
            return Ok(outputDto);
        }
        #region CountAsync

        public async Task<IResult<int>> CountAsync(bool isDeleted = false)
        {
            var count = await _unitOfWork.Categories.CountAsync(c => c.IsDeleted == isDeleted);

            return count > -1
                ? Ok(count)
                : NotFound<int>(BaseLocalization.NoDataAvailableOnRequest);
        }

        #endregion
        public async Task<IResult<CategoryDto>> AddAsync(CategoryAddDto dto, string createdByName)
        {
            var entity = _mapper.Map<Category>(dto);
            entity.SetCreatedByName(createdByName);
            var createdEntity = await _unitOfWork.Categories.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CategoryDto>(createdEntity);
            return Created(outputDto);
        }

        public async Task<IResult<CategoryDto>> UpdateAsync(CategoryUpdateDto dto, string modifiedByName)
        {
            var foundedEntity = await _unitOfWork.Categories.GetAsync(c => c.Id == dto.Id);
            if (foundedEntity is null)
                return NotFound<CategoryDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var entity = _mapper.Map(dto, foundedEntity);
            var updatedEntity = await _unitOfWork.Categories.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CategoryDto>(updatedEntity);
            return Updated(outputDto);
        }

        public async Task<IResult<CategoryDto>> DeleteAsync(int id, string modifiedByName)
        {
            var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == id);
            if (entity == null)
                return NotFound<CategoryDto>(BaseLocalization.NoDataAvailableOnRequest);
            entity.SetIsDeleted(true);
            entity.SetModifiedByName(modifiedByName);
            var deletedEntity = await _unitOfWork.Categories.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CategoryDto>(deletedEntity);
            return Deleted(outputDto);
        }

        public async Task<IResult<bool>> HardDeleteAsync(int id)
        {
            var entity = await _unitOfWork.Categories.GetAsync(c => c.Id == id);
            if (entity == null)
                return NotFound<bool>(BaseLocalization.NoDataAvailableOnRequest);
            await _unitOfWork.Categories.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Deleted(true);
        }

        #endregion
    }
}