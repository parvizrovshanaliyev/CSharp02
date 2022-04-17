using System.ComponentModel;

namespace Blog.Entities.Dtos
{
    public abstract class BaseFilterDto
    {
        [DisplayName("currentPage")]
        public int? CurrentPage { get; set; }
        [DisplayName("pageSize")]
        public int? PageSize { get; set; }
        [DisplayName("isAsc")]
        public bool IsAsc { get; set; }
        [DisplayName("keyword")]
        public string Keyword { get; set; }
    }
}
