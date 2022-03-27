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
            int currentPage = 1,
            int pageSize = 50,
            bool getAll = false) where T : class
        {
            var result = new PagedResult<T>();

            if (!getAll)
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
