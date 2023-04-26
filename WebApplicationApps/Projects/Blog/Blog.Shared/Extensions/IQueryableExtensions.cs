using Blog.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Shared.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedResult<T>> GetManyAndPaginate<T>(
            this IQueryable<T> query,
            int currentPage = default,
            int pageSize = default) where T : class
        {
            var result = new PagedResult<T>();

            if (currentPage > 0 && pageSize > 0)
            {
                result.CurrentPage = currentPage;
                result.PageSize = pageSize;
                result.TotalRowCount = await query.CountAsync();
                var pageCount = (double)result.TotalRowCount / pageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);
                var skip = (currentPage - 1) * pageSize;
                result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();
            }
            else
            {
                result.Results = await query.ToListAsync();
            }

            return result;
        }
    }
}
