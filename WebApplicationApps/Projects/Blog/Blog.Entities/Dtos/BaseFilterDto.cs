namespace Blog.Entities.Dtos
{
    public abstract class BaseFilterDto
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public bool IsAsc { get; set; }
    }
}
