

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Dtos.Post;
using Blog.Services.Abstract;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.Services.Concrete
{
    public class PostManager : BaseServiceResult,IPostService
    {
        #region fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region ctor

        public PostManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        #region methods
        #region QUERY

        #endregion
        #region CRUD
        #region GetAllByNonDeletedAsync
        public async Task<IResult<IList<PostDto>>> GetAllByNonDeletedAsync()
        {
            var entities = await _unitOfWork.Posts.GetAllAsync(i => !i.IsDeleted,p=>p.Category);
            if (entities is null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }
        #endregion
        #endregion

        #endregion
    }
}
